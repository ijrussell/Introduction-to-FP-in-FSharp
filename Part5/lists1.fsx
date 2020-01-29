let items = []

let items = [1;2;3;4;5] 

let items = [1..5] 

let items = [ for x in 1..5 do yield x ]  

let items' = 6 :: items 

let readList items =
    match items with
    | [] -> sprintf "Empty list"
    | head :: tail -> sprintf "Head: %A and Tail: %A" head tail

let emptyList = readList [] // "Empty list"
let multipleList = readList [1;2;3;4;5] // "Head: 1 and Tail: [2;3;4;5]"
let singleItemList = readList [1] // "Head: 1 and Tail: []"

let list1 = [1..5]
let list2 = [3..7]
let emptyList = []

let joined = list1 @ list2 // [1;2;3;4;5;3;4;5;6;7]
let joinedEmpty = list1 @ emptyList // [1;2;3;4;5]
let emptyJoined = emptyList @ list1 // [1;2;3;4;5]

let joined = List.concat [list1;list2]

let items = [(1,0.25M);(5,0.25M);(1,2.25M);(1,125M);(7,10.9M)]

let sum items =
    items
    |> List.map (fun (q, p) -> decimal q * p)
    |> List.sum

let sum items =
    items
    |> List.sumBy (fun (q, p) -> decimal q * p)

