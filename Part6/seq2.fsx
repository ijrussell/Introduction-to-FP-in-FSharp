open System.IO

let readFile path =
    try
        seq { use reader = new StreamReader(File.OpenRead(path))
              while not reader.EndOfStream do
                  yield reader.ReadLine() 
        }
        |> Ok
    with
    | ex -> Error ex

let import path =
    match path |> readFile with
    | Ok data -> data |> Seq.iter (fun x -> printfn "%A" x)
    | Error ex -> printfn "Error: %A" ex.Message

import @"Part6/customers.csv"


