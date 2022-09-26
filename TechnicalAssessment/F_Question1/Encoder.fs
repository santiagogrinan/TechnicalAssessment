module Encoder

let rotatedChar (value : char, rotate : byte) : char = 
    char(byte(value) + rotate)

let distanceChar (value_1 : char, value_2 : char) : byte =
    byte(value_2) - byte(value_1)

let transcodeValue (index : byte) : char option =
    match index with
    | i when i < byte 26 -> Some(rotatedChar('A', i))
    | i when i < byte (26 * 2) -> Some(rotatedChar('a', i - byte(26)))
    | i when i < byte (26 * 2 + 10) -> Some(rotatedChar('0', i - byte(26 * 2)))
    | i when i = byte 62 -> Some('+')
    | i when i = byte 63 -> Some('/')
    | _ -> None

let transcodeIndex (value : char) : byte option = 
    match value with
    | i when (i >= 'A' && i <= 'Z') -> Some(distanceChar ('A', i) + byte(0))
    | i when (i >= 'a' && i <= 'z') -> Some(distanceChar ('a', i) + byte(26))
    | i when (i >= '0' && i <= '9') -> Some(distanceChar ('0', i) + byte(26 * 2))
    | i when i = '+' -> Some(byte 62)
    | i when i = '/' -> Some(byte 63)
    | _ -> None

let encode (input : string) : string =
    let mutable result : string = ""
    let mutable reflex : int = 0

    let addValueFromPivot (pivot : int) = 
        match transcodeValue(byte(pivot)) with
            | Some(x) -> result <- result + string(x)
            | None -> raise (System.Exception("error"))

    let rotateFactors : int list = [2; 4; 6]        

    for i in 0 .. (input.Length - 1) do
        reflex <- reflex <<< 8
        reflex <- reflex + int(byte(input[i]))

        let rotateFactor : int = rotateFactors[i % 3]
        let mask : int = 63 <<< rotateFactor

        let pivot = (reflex &&& mask) >>> rotateFactor
        addValueFromPivot pivot

        reflex <- reflex &&& (~~~mask)

        if (rotateFactor = 6) then
            let newMask = mask >>> 6
            let newPivot = reflex &&& newMask
            addValueFromPivot newPivot
            reflex <- reflex &&& (~~~newMask)
            
    match (input.Length % 3) with
    | 1 -> 
        reflex <- reflex <<< 4
        addValueFromPivot reflex
    | 2 -> reflex <- reflex <<< 2; addValueFromPivot reflex
    | _ -> ()

    result

let decode (input : string) = 
    let mutable result : string = ""
    let mutable reflex : int = 0

    let getIndex (caracter : char) : int = 
        match transcodeIndex(caracter) with
            | Some(x) -> int x
            | None -> raise (System.Exception("error"))

    let addValueFromInt (pivot : int) : unit =
        result <- result + string(char(pivot))
    
    for i in 0 .. (input.Length - 1) do
        reflex <- reflex <<< 6
        reflex <- reflex + getIndex(input[i])

        let rotateFactor = (3 - (i % 4)) * 2

        if (rotateFactor < 6) then
            let mask = 255 <<< rotateFactor
            addValueFromInt((reflex &&& mask) >>> rotateFactor)
            reflex <- reflex &&& (~~~mask)

    result  
        


    

