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

let recalculate items =
    items
    |> List.groupBy (fun i -> i.ProductId)
    |> List.map (fun (id, items) -> { ProductId = id; Quantity = items |> List.sumBy (fun i -> i.Quantity) })

let addItem item order =
    let items = 
        item :: order.Items
        |> recalculate
    { order with Items = items }

let addItems items order =
    let items = 
        items @ order.Items 
        |> recalculate
        |> List.sortBy (fun i -> i.ProductId)
    { order with Items = items }

let removeItem productId order =
    let items = 
        order.Items
        |> List.filter (fun x -> x.ProductId <> productId)
    { order with Items = items }

let reduceItem productId quantity order =
    let items = 
        { ProductId = productId; Quantity = -quantity } :: order.Items
        |> recalculate
        |> List.filter (fun x -> x.Quantity > 0)
    { order with Items = items }

let clearItems order = 
    { order with Items = [] }

let order = { Id = 1; Items = [ { ProductId = 1; Quantity = 1 } ] }
let newItem = { ProductId = 1; Quantity = 1 }

