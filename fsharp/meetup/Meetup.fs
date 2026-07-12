module Meetup

open System

type Week = First | Second | Third | Fourth | Last | Teenth

let meetup (year: int) (month: int) (week: Week) (dayOfWeek: DayOfWeek): DateTime =
    let firstOfMonth    = DateTime(year, month, 1)
    let firstDayOfWeek  = (int dayOfWeek - int firstOfMonth.DayOfWeek + 7) % 7
    let firstOccurrence = firstOfMonth.AddDays(float firstDayOfWeek)
    match week with
    | First  -> firstOccurrence
    | Second -> firstOccurrence.AddDays( 7.0)
    | Third  -> firstOccurrence.AddDays(14.0)
    | Fourth -> firstOccurrence.AddDays(21.0)
    | Last   ->
        let lastDayOfMonth = DateTime(year, month, DateTime.DaysInMonth(year, month))
        let lastDayOfWeek  = (int lastDayOfMonth.DayOfWeek - int dayOfWeek + 7) % 7
        lastDayOfMonth.AddDays(float (-lastDayOfWeek))
    | Teenth ->
        let teenthStart     = DateTime(year, month, 13)
        let teenthDayOfWeek = (int dayOfWeek - int teenthStart.DayOfWeek + 7) % 7
        teenthStart.AddDays(float teenthDayOfWeek)
