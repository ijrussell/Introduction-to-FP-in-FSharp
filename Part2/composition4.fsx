//let calculateTotal customer spend = ... // Customer -> decimal -> decimal

//Customer -> (decimal -> decimal)

type LogLevel = 
    | Error
    | Warning
    | Info

let log (level:LogLevel) message =
    printfn "[%A]: %s" level message
    ()

let logError = log Error

log Error "Curried function" 
logError "Partially Applied function"

