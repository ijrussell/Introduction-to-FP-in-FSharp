type Customer = {
    Id : int
    IsVip : bool
    Credit : decimal
}

let getPurchases customer =
    try
        // Imagine this function is fetching data from a Database
        let purchases = if customer.Id % 2 = 0 then (customer, 120M) else (customer, 80M)
        Ok purchases
    with
    | ex -> Error ex

let tryPromoteToVip purchases =
    let customer, amount = purchases
    if amount > 100M then { customer with IsVip = true }
    else customer

let increaseCreditIfVip customer =
    try
        // Imagine this function could cause an exception           
        let result = 
            if customer.IsVip then { customer with Credit = customer.Credit + 100M }
            else { customer with Credit = customer.Credit + 50M }
        Ok result
    with
    | ex -> Error ex

let map oneTrackFunction resultInput =
    match resultInput with
    | Ok s -> Ok (oneTrackFunction s)
    | Error f -> Error f

let bind switchFunction resultInput =
    match resultInput with
    | Ok s -> switchFunction s
    | Error f -> Error f
    
let upgradeCustomer customer =
    customer 
    |> getPurchases 
    |> map tryPromoteToVip
    |> bind increaseCreditIfVip

let customerVIP = { Id = 1; IsVip = true; Credit = 0.0M }
let customerSTD = { Id = 2; IsVip = false; Credit = 100.0M }

let assertVIP = upgradeCustomer customerVIP = Ok {Id = 1; IsVip = true; Credit = 100.0M }
let assertSTDtoVIP = upgradeCustomer customerSTD = Ok {Id = 2; IsVip = true; Credit = 200.0M }
let assertSTD = upgradeCustomer { customerSTD with Id = 3; Credit = 50.0M } = Ok {Id = 3; IsVip = false; Credit = 100.0M }