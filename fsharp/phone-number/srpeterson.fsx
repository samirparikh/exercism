module PhoneNumber
open System

type PhoneType = TenDigit | ElevenDigit

type ValidationFailure =
    | CanNotContainLetters
    | CanNotContainPunctuation
    | LessThanTenDigits
    | GreaterThanElevenDigits
    | ElevenDigitsDoesntStartWithOne
    | AreaCodeCanNotStartWithZero
    | AreaCodeCanNotStartWithOne
    | ExchangeCodeCanNotStartWithZero
    | ExchangeCodeCanNotStartWithOne

let [<Literal>] zero = '0'
let [<Literal>] one = '1'

let getNumbers input = String.filter Char.IsNumber input
let getlength input = input |> getNumbers |> String.length

let getPhoneType input =
    match getlength input with 
    | l when l = 10 -> TenDigit
    | l when l = 11 -> ElevenDigit
    | _ -> failwith "Invalid number of digits"

let removeCountryCode number = 
    match getPhoneType number with
    | TenDigit -> number |> getNumbers
    | ElevenDigit ->
        number |> getNumbers |> Seq.tail |> String.Concat

let result rule failure input =
    if rule 
    then Ok input 
    else Error failure

let validateAreaCode num reason input =
    let firstNumber = input |> removeCountryCode |> Seq.tryHead 
    let rule = firstNumber <> Some num
    input |> result rule reason 

let validateExchange num reason input =
    let firstNumber = 
        input 
        |> removeCountryCode 
        |> List.ofSeq 
        |> List.splitAt 3
        |> snd
        |> String.Concat
        |> Seq.tryHead
    let rule = firstNumber <> Some num
    input |> result rule reason

let doesNotContainLetters input =
    let rule = String.exists Char.IsLetter input |> not
    input |> result rule CanNotContainLetters

let doesNotContainPunctuation input =
    let allowedPunctuation = set "().-+"
    let inputPunctuation = 
        input 
        |> String.filter(fun ch -> Char.IsPunctuation ch || ch ='+') 
        |> set
    let rule = Set.union allowedPunctuation inputPunctuation = allowedPunctuation
    input |> result rule CanNotContainPunctuation

let isLessTenDigits input =
    let rule = getlength input > 9 
    input |> result rule LessThanTenDigits

let isGreaterElevenDigits input =
    let rule = getlength input < 12
    input |> result rule GreaterThanElevenDigits

let elevenDigitsNotStartsOne input =
    match getPhoneType input with
    | ElevenDigit -> 
        let firstNumber = input |> getNumbers |> Seq.tryHead
        let rule = firstNumber = Some '1'
        input |> result rule ElevenDigitsDoesntStartWithOne
    | _ -> Ok input

let areaCodeNotStartsZero input = 
    input |> validateAreaCode zero AreaCodeCanNotStartWithZero

let areaCodeNotStartsOne input = 
    input |> validateAreaCode one AreaCodeCanNotStartWithOne

let exchangeNotStartsZero input = 
    input |> validateExchange zero ExchangeCodeCanNotStartWithZero

let exchangeNotStartsOne input = 
    input |> validateExchange one ExchangeCodeCanNotStartWithOne

let getErrorMessage = function
    | CanNotContainLetters -> "letters not permitted"
    | CanNotContainPunctuation -> "punctuations not permitted"
    | LessThanTenDigits  -> "incorrect number of digits"
    | GreaterThanElevenDigits ->  "more than 11 digits"
    | ElevenDigitsDoesntStartWithOne ->  "11 digits must start with 1"
    | AreaCodeCanNotStartWithZero -> "area code cannot start with zero"
    | AreaCodeCanNotStartWithOne -> "area code cannot start with one"
    | ExchangeCodeCanNotStartWithZero -> "exchange code cannot start with zero"
    | ExchangeCodeCanNotStartWithOne -> "exchange code cannot start with one"

let clean input =

    let okWorkflow number = number |> removeCountryCode |> uint64
    let errorWorkflow failure = getErrorMessage failure

    Ok input
    |> Result.bind doesNotContainLetters
    |> Result.bind doesNotContainPunctuation
    |> Result.bind isLessTenDigits
    |> Result.bind isGreaterElevenDigits
    |> Result.bind elevenDigitsNotStartsOne
    |> Result.bind areaCodeNotStartsZero
    |> Result.bind areaCodeNotStartsOne
    |> Result.bind exchangeNotStartsZero
    |> Result.bind exchangeNotStartsOne
    |> Result.map okWorkflow
    |> Result.mapError errorWorkflow

