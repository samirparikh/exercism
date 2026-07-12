module PhoneNumber
open System

let clean (input: string): Result<uint64,string> =
    let cleanChars = ['+';'(';')';'-';' '; '.']
    let numberStr = 
        input.ToCharArray()
        |> Array.filter (fun c -> not (cleanChars |> List.contains c))
        |> String
    
    if numberStr.Length < 10 then 
        Error "must not be fewer than 10 digits"
    elif numberStr.Length > 11 then 
        Error "must not be greater than 11 digits"
    elif numberStr.Length = 11 && numberStr.[0] <> '1' then 
        Error "11 digits must start with 1"
    elif numberStr |> String.exists (fun c -> Char.IsLetter c) then
        Error "letters not permitted"
    elif numberStr |> String.exists (fun c -> Char.IsPunctuation c) then
        Error "punctuations not permitted"
    elif numberStr[numberStr.Length - 10] = '0' then
        Error "area code cannot start with zero"
    elif numberStr[numberStr.Length - 10] = '1' then
        Error "area code cannot start with one"
    elif numberStr[numberStr.Length - 7] = '0' then
        Error "exchange code cannot start with zero"
    elif numberStr[numberStr.Length - 7] = '1' then
        Error "exchange code cannot start with one"
    else
        Ok (uint64 numberStr[numberStr.Length - 10..])
