module PhoneNumber

open System

let private scrub (input: string) =
    let validPunctuation = [ '('; ')'; '-'; '.'; '+'; ' ' ]

    input
    |> String.filter (fun c -> not (List.contains c validPunctuation))

let private validateLength input =
    match String.length input with
    | length when length < 10 -> Error "incorrect number of digits"
    | length when length > 11 -> Error "more than 11 digits"
    | _ -> Ok input

let private validateCountryCode input =
    match String.length input with
    | 11 when input.[0] <> '1' -> Error "11 digits must start with 1"
    | 11 -> Ok input.[1..]
    | _ -> Ok input

let private validateNoLetters input =
    if String.exists Char.IsLetter input then Error "letters not permitted" else Ok input

let private validateNoPunctuation input =
    if String.exists Char.IsPunctuation input then Error "punctuations not permitted" else Ok input

let private validateAreaCode (input: string) =
    match input.[0] with
    | '0' -> Error "area code cannot start with zero"
    | '1' -> Error "area code cannot start with one"
    | _ -> Ok input

let private validateExchangeCode (input: string) =
    match input.[3] with
    | '0' -> Error "exchange code cannot start with zero"
    | '1' -> Error "exchange code cannot start with one"
    | _ -> Ok input

let clean (input: string): Result<uint64, string> =
    input
    |> scrub
    |> validateLength
    |> Result.bind validateCountryCode
    |> Result.bind validateNoLetters
    |> Result.bind validateNoPunctuation
    |> Result.bind validateAreaCode
    |> Result.bind validateExchangeCode
    |> Result.map uint64
