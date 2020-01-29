open System

let tryDivide (x:decimal) (y:decimal) =
    try
        x/y 
    with
    | :? DivideByZeroException as ex -> raise ex

// type Result<'TSuccess,'TFailure> = 
//    | Ok of 'TSuccess
//    | Error of 'TFailure

// let tryDivide (x:decimal) (y:decimal) = // decimal -> decimal -> Result<decimal,exn>
//     try
//         Ok (x/y) 
//     with
//     | :? DivideByZeroException as ex -> Error ex

let badDivide = tryDivide 1M 0M
let goodDivide = tryDivide 1M 1M