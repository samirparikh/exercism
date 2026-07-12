module Gigasecond

open System

let add (beginDate: DateTime) =
    beginDate.Add (TimeSpan(0, 0, 0, 1_000 * 1_000_000))
