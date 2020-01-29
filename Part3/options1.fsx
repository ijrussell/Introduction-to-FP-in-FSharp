// type Option<'T> =
//     | Some of 'T
//     | None

open System

let tryParseDateTime (input:string) =
    let (success, result) = DateTime.TryParse input
    if success then Some result
    else None

// let tryParseDateTime (input:string) =
//     match DateTime.TryParse input with
//     | true, result -> Some result
//     | _ -> None

let isDate = tryParseDateTime "2019-08-01"
let isNotDate = tryParseDateTime "Hello"

type PersonName = {
    FirstName : string
    MiddleName : string option // or Option<string>
    LastName : string
}

let person = { FirstName = "Ian"; MiddleName = None; LastName = "Russell"}
let person' = { person with MiddleName = Some "????" }

