type Category = 
    | Ones
    | Twos
    | Threes
    | Fours
    | Fives
    | Sixes
    | FullHouse
    | FourOfAKind
    | LittleStraight
    | BigStraight
    | Choice
    | Yacht

type Die =
    | One 
    | Two 
    | Three
    | Four 
    | Five 
    | Six

let dice = [Die.One; Die.Three; Die.Three; Die.Two; Die.Five]

let result = dice |> List.countBy id |> List.tryFind (function (One, _) -> true | _ -> false)

let diceCounts = dice |> List.countBy id
let onesCount =
    diceCounts
    |> List.tryFind (fun die -> fst die = One)
    |> Option.map snd
    |> Option.defaultValue 0

let foursCount =
    diceCounts
    |> List.tryFind (fun die -> fst die = Four)
    |> Option.map snd
    |> Option.defaultValue 0
