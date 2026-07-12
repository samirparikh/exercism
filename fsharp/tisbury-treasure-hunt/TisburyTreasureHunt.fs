module TisburyTreasureHunt

let getCoordinate (line: string * string): string = snd line

let convertCoordinate (coordinate: string): int * char = 
    (int coordinate[0] - int '0', coordinate[1])

let compareRecords (azarasData: string * string) (ruisData: string * (int * char) * string) : bool = 
    let treasureCoordinate =
        azarasData
        |> getCoordinate
        |> convertCoordinate
    let _, coordinate, _ = ruisData
    treasureCoordinate = coordinate

let createRecord (azarasData: string * string) (ruisData: string * (int * char) * string) : (string * string * string * string) =
    if (compareRecords azarasData ruisData) then
        let treasure, coordinate = azarasData
        let location, _, quadrant = ruisData
        (coordinate, location, quadrant, treasure)
    else ("", "", "", "")
        
