module Raindrops

let convert (number: int): string =
    match number with
    | _ when number % (3 * 5 * 7) = 0 -> "PlingPlangPlong"
    | _ when number % (5 * 7) = 0     -> "PlangPlong"
    | _ when number % (3 * 7) = 0     -> "PlingPlong"
    | _ when number % (3 * 5) = 0     -> "PlingPlang"
    | _ when number % 7 = 0           -> "Plong"
    | _ when number % 5 = 0           -> "Plang"
    | _ when number % 3 = 0           -> "Pling"
    | _ -> number.ToString()
