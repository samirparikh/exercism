module Yacht

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

let score category dice =
    match category with
    | Ones -> List.sumBy (function One -> 1 | _ -> 0) dice
    | Twos -> List.sumBy (function Two -> 2 | _ -> 0) dice
    | Threes -> List.sumBy (function Three -> 3 | _ -> 0) dice
    | Fours -> List.sumBy (function Four -> 4 | _ -> 0) dice
    | Fives -> List.sumBy (function Five -> 5 | _ -> 0) dice
    | Sixes -> List.sumBy (function Six -> 6 | _ -> 0) dice
    | FullHouse -> 0
    | FourOfAKind -> 0
    | LittleStraight ->
        if List.sort dice = [One; Two; Three; Four; Five] then 30 else 0
    | BigStraight ->
        if List.sort dice = [Two; Three; Four; Five; Six] then 30 else 0
    | Choice ->
        List.sumBy (
            function
            | One -> 1
            | Two -> 2
            | Three -> 3
            | Four -> 4
            | Five -> 5
            | Six -> 6) dice
    | Yacht -> if List.forall ((=) (List.head dice)) dice then 50 else 0
