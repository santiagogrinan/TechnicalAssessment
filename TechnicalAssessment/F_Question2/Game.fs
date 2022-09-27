module Game

open System
open System.Collections.Generic
open System.Linq

type Result = 
    | Undefined
    | Win
    | Tie
    | Lose

type Player = {
    Name : string
    Cards : Cards.Card list
    Result : Result
}

let private createPlayer (names: string list) : Player list =
    let mutable result : Player list = []
    
    for name in names do 
        let player : Player = {
                Name = name
                Cards = []
                Result = Result.Undefined
            }
        result <- result |> List.append([player])

    result

let private dealACard (players : Player list, deck : Deck.IDeck) : Player list = 
    let mutable result : Player list = []
    
    for player in players do
        let newPlayer : Player = { player with Cards = player.Cards |> List.append([deck.GetCard]) }
        result <- result |> List.append([newPlayer])

    result

let rec private getIndexStartLoser (orderedPlayer : Player list, comparer : IComparer<Cards.Card list>, startIndex : int) :int = 
    match comparer.Compare(orderedPlayer[0].Cards, orderedPlayer[startIndex].Cards) with
    | 0 -> getIndexStartLoser(orderedPlayer, comparer, startIndex + 1)
    | _ -> startIndex

let private setResult (orderedPlayer : Player list, comparer : IComparer<Cards.Card list>) : Player list =
    let mutable result : Player list = []

    let indexLoser = getIndexStartLoser(orderedPlayer, comparer, 0)

    let resultFirstPlayer =
        match indexLoser <= 1 with
        | true -> Result.Win
        | false -> Result.Tie

    result <- result |> List.append([{orderedPlayer[0] with Result = resultFirstPlayer }])

    for i in [1.. orderedPlayer.Length] do
        let itemResult : Result =         
            match i <= indexLoser with
            | true -> Result.Win
            | false -> Result.Tie
        result <- result |> List.append([{orderedPlayer[0] with Result = itemResult }])

    result
        
let game (deck : Deck.IDeck, comparer : IComparer<Cards.Card list>, allowTie : bool) : string list -> Player list =

    let result (names : string list) : Player list =
        let initPlayer = createPlayer (names)
        let dealedPlayer = dealACard (initPlayer, deck)
        let orderedPlayer = (dealedPlayer |> List.toArray).OrderBy(fun x -> x.Cards, comparer) |> List.ofSeq
        let resultPlayer = setResult(orderedPlayer, comparer)

        match allowTie with
        | true -> resultPlayer
        | false -> 
            let mutable foundWinner = false
            let mutable currentPlayer = resultPlayer

            while foundWinner = false do
                let dealedPlayer = dealACard (currentPlayer, deck)
                let orderedPlayer = (dealedPlayer |> List.toArray).OrderBy(fun x -> x.Cards, comparer) |> List.ofSeq
                let resultPlayer = setResult(orderedPlayer, comparer)
                currentPlayer <- resultPlayer
                if (currentPlayer[0].Result = Result.Win) then 
                    foundWinner <- true

            currentPlayer

    result
    

