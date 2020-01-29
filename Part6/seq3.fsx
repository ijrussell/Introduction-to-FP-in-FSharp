open System.IO

type Customer = {
    CustomerId : string
    Email : string
    IsEligible : string
    IsRegistered : string
    DateRegistered : string
    Discount : string
}

let readFile path =
    try
        seq { use reader = new StreamReader(File.OpenRead(path))
              while not reader.EndOfStream do
                  yield reader.ReadLine() 
        }
        |> Ok
    with
    | ex -> Error ex

let parse (data:string seq) =
    data
    |> Seq.skip 1 // Ignore the header row
    |> Seq.map (fun line -> 
        match line.Split('|') with
        | [| customerId; email; eligible; registered; dateRegistered; discount |] -> 
            Some { 
                CustomerId = customerId
                Email = email
                IsEligible = eligible
                IsRegistered = registered
                DateRegistered = dateRegistered
                Discount = discount
             }
        | _ -> None
    )
    |> Seq.choose id // Ignore None and unwrap Some

let output data =
    data 
    |> Seq.iter (fun x -> printfn "%A" x)

let import path =
    match path |> readFile with
    | Ok data -> data |> parse |> output
    | Error ex -> printfn "Error: %A" ex.Message

import @"Part6/customers.csv"
