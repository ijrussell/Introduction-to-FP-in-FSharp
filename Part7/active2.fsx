open System

let (|IsValidDate|_|) input =
    let (success, value) = DateTime.TryParse(input)
    if success then Some value else None

let parse input =
    match input with
    | IsValidDate d -> printfn "%A" d
    | _ -> printfn "%s is not a valid date" input

let isDate = parse "2019-12-20" // 2019-12-20 00:00:00
let isNotDate = parse "Hello" // Hello is not a valid date