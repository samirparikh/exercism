module SpaceAge

type Planet =
    | Mercury
    | Venus
    | Earth
    | Mars
    | Jupiter
    | Saturn
    | Uranus
    | Neptune

let age (planet: Planet) (seconds: int64): float =
    let earthAge = float seconds / 60.0 / 60.0 / 24.0 / 365.25
    match planet with
    | Mercury -> earthAge / 0.2408467
    | Venus -> earthAge / 0.61519726
    | Earth -> earthAge
    | Mars -> earthAge / 1.8808158
    | Jupiter -> earthAge / 11.862615
    | Saturn -> earthAge / 29.447498
    | Uranus -> earthAge / 84.016846
    | Neptune -> earthAge / 164.79132
