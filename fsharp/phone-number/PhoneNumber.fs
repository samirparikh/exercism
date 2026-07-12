// solution inspired by:
// https://patrickt.one/20201020-in-a-bind-with-fsharp.html
// which in turn was inspired by:
// https://exercism.org/tracks/fsharp/exercises/phone-number/solutions/7a5d2cf04216475cab7ea251fd8289a9
// and
// https://exercism.org/tracks/fsharp/exercises/phone-number/solutions/9016c15f70854770a2970df61cdbe280

module PhoneNumber

open System

type PhoneNumberValidationError =
    | FewerThan10Digits
    | MoreThan11Digits
    | ContainsLetters
    | ContainsPunctuation
    | ElevenDigitsMustStartWith1
    | AreaCodeCannotStartWith0
    | AreaCodeCannotStartWith1
    | ExchangeCodeCannotStartWith0
    | ExchangeCodeCannotStartWith1
    member this.Message =
        match this with
        | FewerThan10Digits            -> "must not be fewer than 10 digits"
        | MoreThan11Digits             -> "must not be greater than 11 digits"
        | ContainsLetters              -> "letters not permitted"
        | ContainsPunctuation          -> "punctuations not permitted"
        | ElevenDigitsMustStartWith1   -> "11 digits must start with 1"
        | AreaCodeCannotStartWith0     -> "area code cannot start with zero"
        | AreaCodeCannotStartWith1     -> "area code cannot start with one"
        | ExchangeCodeCannotStartWith0 -> "exchange code cannot start with zero"
        | ExchangeCodeCannotStartWith1 -> "exchange code cannot start with one"

type PhoneNumberResult = private PhoneNumberResult of uint64

module PhoneNumberResult =

    let private removeValidPunctuation input =
        let validPunctuation = [ '('; ')'; '-'; '.'; '+'; ' ' ]
        Ok (
            input
            |> String.filter (fun c -> not (List.contains c validPunctuation))
        )

    let private validateNoLetters input =
        if String.exists System.Char.IsLetter input then Error ContainsLetters
        else Ok input

    let private validateNoPunctuation input =
        if String.exists Char.IsPunctuation input then Error ContainsPunctuation
        else Ok input

    let private validateLength input =
        match String.length input with
        | length when length < 10 -> Error FewerThan10Digits
        | length when length > 11 -> Error MoreThan11Digits
        | _ -> Ok input

    let private validateCountryCode input =
        match String.length input with
        | 11 when input.[0] <> '1' -> Error ElevenDigitsMustStartWith1
        | 11 -> Ok input.[1..]
        | _ -> Ok input

    let private validateAreaCode (input : string) =
        match input.[0] with
        | '0' -> Error AreaCodeCannotStartWith0
        | '1' -> Error AreaCodeCannotStartWith1
        | _ -> Ok input
    
    let private validateExchangeCode (input : string) =
        match input.[3] with
        | '0' -> Error ExchangeCodeCannotStartWith0
        | '1' -> Error ExchangeCodeCannotStartWith1
        | _ -> Ok input

    let unwrap (PhoneNumberResult phoneNumber) = phoneNumber

    let create phoneNumber =
        phoneNumber
        |> removeValidPunctuation
        |> Result.bind validateNoLetters
        |> Result.bind validateNoPunctuation
        |> Result.bind validateLength
        |> Result.bind validateCountryCode
        |> Result.bind validateAreaCode
        |> Result.bind validateExchangeCode
        |> Result.map uint64
        |> Result.map PhoneNumberResult

let clean input =
    match PhoneNumberResult.create input with
    | Ok phoneNumberResult -> Ok (PhoneNumberResult.unwrap phoneNumberResult)
    | Error error -> Error error.Message
