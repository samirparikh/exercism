module Clock

type Clock = { Hours: int; Minutes: int }

let private normalizeTime totalMinutes =
    let minutes           = totalMinutes % 60
    let normalizedHours   = (totalMinutes / 60) % 24
    let normalizedMinutes = if minutes < 0 then minutes + 60 else minutes
    let hourAdjustment    = if minutes < 0 then -1 else 0
    {
        Hours   = (normalizedHours + hourAdjustment + 24) % 24
        Minutes = (normalizedMinutes + 60) % 60
    }

let create hours minutes =
    normalizeTime (hours * 60 + minutes)

let add minutes clock =
    normalizeTime (clock.Hours * 60 + clock.Minutes + minutes)

let subtract minutes clock =
    normalizeTime (clock.Hours * 60 + clock.Minutes - minutes)

let display clock = sprintf "%02d:%02d" clock.Hours clock.Minutes
