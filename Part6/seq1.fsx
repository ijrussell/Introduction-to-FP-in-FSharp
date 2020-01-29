open System.IO

let readFile path =
    seq { use reader = new StreamReader(File.OpenRead(path))
          while not reader.EndOfStream do
              yield reader.ReadLine() 
    }

@"Part6/customers.csv"
|> readFile 
|> Seq.iter (fun x -> printfn "%s" x)

// let readFile path =
//     try
//         seq { use reader = new StreamReader(File.OpenRead(path))
//               while not reader.EndOfStream do
//                   yield reader.ReadLine() 
//         }
//         |> Ok
//     with
//     | ex -> Error ex

