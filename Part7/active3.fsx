// 300 points for predicting the correct score (2-3 vs 2-3)
// 100 points for predicting the correct result (2-3 vs 0-2)
// 15 points per home goal & 20 points per away goal using the lower of the predicted and actual scores

// (0, 0) (0, 0) = 400 // 300 + 100 + 0 * 15 + 0 * 20
// (3, 2) (3, 2) = 485 // 300 + 100 = 3 * 15 * 2 * 20
// (5, 1) (4, 3) = 180 // 100 + 4 * 15 + 1 * 20
// (2, 1) (0, 7) = 20 // 0 * 15 + 1 * 20
// (2, 2) (3, 3) = 170 //100 + 2 * 15 + 2 * 20

type Score = int * int

let (|CorrectScore|_|) (expected:Score, actual:Score) =
    if expected = actual then Some () else None

let (|Draw|HomeWin|AwayWin|) (score:Score) =
    match score with
    | (h, a) when h = a -> Draw
    | (h, a) when h > a -> HomeWin
    | _ -> AwayWin

let (|CorrectResult|_|) (expected:Score, actual:Score) =
    match (expected, actual) with
    | (Draw, Draw) -> Some ()
    | (HomeWin, HomeWin) -> Some ()
    | (AwayWin, AwayWin) -> Some ()
    | _ -> None

// let (|CorrectResult|_|) (expected:Score, actual:Score) =
//     match (expected, actual) with
//     | ((h, a), (h', a')) when h = a && h' = a' -> Some ()
//     | ((h, a), (h', a')) when h > a && h' > a' -> Some ()
//     | ((h, a), (h', a')) when h < a && h' < a' -> Some ()
//     | _ -> None

let goalsScore (expected:Score) (actual:Score) =
    let (h, a) = expected
    let (h', a') = actual
    let home = [ h; h' ] |> List.min
    let away = [ a; a' ] |> List.min
    (home * 15) + (away * 20)

let calculatePoints (expected:Score) (actual:Score) =
    let pointsForCorrectScore = 
        match (expected, actual) with
        | CorrectScore -> 300
        | _ -> 0
    let pointsForCorrectResult =
        match (expected, actual) with
        | CorrectResult -> 100
        | _ -> 0
    let pointsForGoals = goalsScore expected actual
    pointsForCorrectScore + pointsForCorrectResult + pointsForGoals 

let assertnoScoreDrawCorrect = calculatePoints (0, 0) (0, 0) = 400
let assertHomeWinExactMatch = calculatePoints (3, 2) (3, 2) = 485
let assertHomeWin = calculatePoints (5, 1) (4, 3) = 180
let assertIncorrect = calculatePoints (2, 1) (0, 7) = 20
let assertDraw = calculatePoints (2, 2) (3, 3) = 170

