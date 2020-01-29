type RegisteredCustomer = {
    Id : string
    IsEligible : bool
}

type UnregisteredCustomer = {
    Id : string
}

type Customer =
    | RegisteredCustomer of RegisteredCustomer
    | Guest of UnregisteredCustomer

let calculateTotal customer spend =
    let discount = 
        match customer with
        | RegisteredCustomer c -> if c.IsEligible && spend >= 100.0M then (spend * 0.1M) else 0.0M
        | Guest _ -> 0.0M
    spend - discount

// let calculateTotal customer spend =
//     let discount = 
//         match customer with
//         | RegisteredCustomer c -> if c.IsEligible && spend >= 100.0M then (spend * 0.1M) else 0.0M
//         | _ -> 0.0M
//     spend - discount

let john = RegisteredCustomer { Id = "John"; IsEligible = true }
let mary = RegisteredCustomer { Id = "Mary"; IsEligible = true }
let richard = RegisteredCustomer { Id = "Richard"; IsEligible = false }
let sarah = Guest { Id = "Sarah" } // Guest of UnregisteredCustomer

let assertJohn = calculateTotal john 100.0M = 90.0M
let assertMary = calculateTotal mary 99.0M = 99.0M
let assertRichard = calculateTotal richard 100.0M = 100.0M
let assertSarah = calculateTotal sarah 100.0M = 100.0M

