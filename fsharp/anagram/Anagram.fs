module Anagram

let findAnagrams (sources: string list) (target: string)=
    sources
    
    // remove candidates that match the target word
    |> List.filter (fun word -> word.ToLower() <> target.ToLower())
    
    // take remaining candidate list and map it to a list of tuples where fst is
    // the original word and snd is a sorted list of word's character
    // e.g. (("hello", ['e'; 'h'; 'l'; 'l'; 'o']))
    |> List.map (fun x -> (x, x.ToLower() |> Seq.sort |> Seq.toList))
    
    // retain only those elements of the list where the sorted characters `chars`
    // equal the sorted characters of the target word
    |> List.filter (fun (_, chars) -> chars = (target.ToLower() |> Seq.sort |> Seq.toList))
    
    // return list of just the words (first element of the tuple)
    |> List.map fst;;

// better solution
// let findAnagrams (sources: string list) (target: string) =
//     let sortedChars (word: string) = word.ToLower() |> Seq.sort |> Seq.toList
//     let sortedTarget = sortedChars target
//     let lowerTarget = target.ToLower()
//     
//     sources
//     |> List.filter (fun word -> word.ToLower() <> lowerTarget)
//     |> List.filter (fun word -> sortedChars word = sortedTarget)
