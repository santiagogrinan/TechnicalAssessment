// Learn more about F# at http://fsharp.org

open System

let test (message : string) : unit =
    printfn "//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::"
    let encoded = Encoder.encode message
    let decoded = Encoder.decode encoded
    printfn $"{message} --> {encoded}"
    printfn $"{encoded} --> {decoded}"
    printfn ""


[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    try
        test "This is a test string"
        0
    with 
        | x -> 
            printfn $"{x.Message}"
            1
