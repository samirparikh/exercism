module AnnalynsInfiltration

let canFastAttack (knightIsAwake: bool): bool =
    if knightIsAwake then false else true

let canSpy (knightIsAwake: bool) (archerIsAwake: bool) (prisonerIsAwake: bool): bool =
    if knightIsAwake || archerIsAwake || prisonerIsAwake then true else false

let canSignalPrisoner (archerIsAwake: bool) (prisonerIsAwake: bool): bool =
    if not archerIsAwake && prisonerIsAwake then true else false

let canFreePrisoner (knightIsAwake: bool) (archerIsAwake: bool) (prisonerIsAwake: bool) (petDogIsPresent: bool): bool =
    if (petDogIsPresent && not archerIsAwake) ||
        (prisonerIsAwake && not knightIsAwake && not archerIsAwake) then true else false
