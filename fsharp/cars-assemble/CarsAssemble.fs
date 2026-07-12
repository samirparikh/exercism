module CarsAssemble

let successRate (speed: int): float =
    match speed with
    | 0       -> 0.0
    | 1|2|3|4 -> 1.0
    | 5|6|7|8 -> 0.9
    | 9       -> 0.8
    | 10      -> 0.77
    | _       -> 0.0

let productionRatePerHour (speed: int): float =
    float (speed * 221) * successRate speed

let workingItemsPerMinute (speed: int): int =
    int (productionRatePerHour speed) / 60