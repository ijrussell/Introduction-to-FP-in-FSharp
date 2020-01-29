type Customer = {
    Id : string
    IsEligible : bool
    IsRegistered : bool
}

let fred = { Id = "Fred"; IsEligible = true; IsRegistered = true }

let calculateTotal (customer:Customer) (spend:decimal) : decimal =
    let discount = if customer.IsRegistered && customer.IsEligible && spend >= 100.0M then (spend * 0.1M) else 0.0M   
    let total = spend - discount
    total

// let calculateTotal customer spend =
//     let discount = if customer.IsRegistered && customer.IsEligible && spend >= 100.0M then (spend * 0.1M) else 0.0M   
//     spend - discount

let john = { Id = "John"; IsEligible = true; IsRegistered = true }
let mary = { Id = "Mary"; IsEligible = true; IsRegistered = true }
let richard = { Id = "Richard"; IsEligible = false; IsRegistered = true }
let sarah = { Id = "Sarah"; IsEligible = false; IsRegistered = false }

let assertJohn = calculateTotal john 100.0M = 90.0M
let assertMary = calculateTotal mary 99.0M = 99.0M
let assertRichard = calculateTotal richard 100.0M = 100.0M
let assertSarah = calculateTotal sarah 100.0M = 100.0M

