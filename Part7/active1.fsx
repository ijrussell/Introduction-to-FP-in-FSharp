let calculate i =
    if i % 3 = 0 && i % 5 = 0 then "FizzBuzz"
    elif i % 3 = 0 then "Fizz"
    elif i % 5 = 0 then "Buzz"
    else i |> string

[1..15] |> List.map calculate

let calculate i =
    match (i % 3, i % 5) with
    | (0, 0) -> "FizzBuzz"
    | (0, _) -> "Fizz"
    | (_, 0) -> "Buzz"
    | _ -> i |> string

let (|IsDivisibleBy|_|) divisor n  =
    if n % divisor = 0 then Some () else None

let calculate i =
    match i with
    | IsDivisibleBy 3 & IsDivisibleBy 5 -> "FizzBuzz"
    | IsDivisibleBy 3 -> "Fizz"
    | IsDivisibleBy 5 -> "Buzz"
    | _ -> i |> string

let calculate i =
    match i with
    | IsDivisibleBy 3 & IsDivisibleBy 5 & IsDivisibleBy 7 -> "FizzBuzzBazz"
    | IsDivisibleBy 3 & IsDivisibleBy 5 -> "FizzBuzz"
    | IsDivisibleBy 3 & IsDivisibleBy 7 -> "FizzBazz"
    | IsDivisibleBy 5 & IsDivisibleBy 7 -> "BuzzBazz"
    | IsDivisibleBy 3 -> "Fizz"
    | IsDivisibleBy 5 -> "Buzz"
    | IsDivisibleBy 7 -> "Bazz"
    | _ -> i |> string

let calculate mapping n =
    mapping
    |> List.map (fun (divisor, text) -> if n % divisor = 0 then text else "")
    |> List.fold (+) "" 
    |> function
        | "" -> n |> string 
        | result -> result

[1..15] |> List.map (fun n -> ([(3, "Fizz"); (5, "Buzz")], n) ||> calculate)
[1..15] |> List.map (fun n -> ([(3, "Fizz"); (5, "Buzz"); (7, "Bazz")], n) ||> calculate)