// Add an item
// Remove an item
// Reduce quantity of an item
// Clear all of the items

type Item = {
    ProductId : int
    Quantity : int
}

type Order = {
    Id : int
    Items : Item list
}

let order = { Id = 1; Items = [ { ProductId = 1; Quantity = 1 } ] }
let newItem = { ProductId = 1; Quantity = 1 }

let addItem item order =
    let items = 
        item :: order.Items
        |> List.groupBy (fun i -> i.ProductId) // (int * Item list) list
        |> List.map (fun (id, items) -> { ProductId = id; Quantity = items |> List.sumBy (fun i -> i.Quantity) })
    { order with Items = items }

let result = addItem newItem order // [ { ProductId = 1; Quantity = 2 } ]

let addItems items order = // Item list -> Order -> Order
    let items = 
        items @ order.Items 
        |> List.groupBy (fun i -> i.ProductId)
        |> List.map (fun (id, items) -> { ProductId = id; Quantity = items |> List.sumBy (fun i -> i.Quantity) })
        |> List.sortBy (fun i -> i.ProductId)
    { order with Items = items }

