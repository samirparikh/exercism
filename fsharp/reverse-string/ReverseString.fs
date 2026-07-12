module ReverseString

let reverse (input: string): string =
    input
    |> Seq.rev          // revereses sequence of characters
    |> Seq.toArray      // converts reversed sequence to array of characters
    |> System.String    // creates new string from array of characters
