module HighCardCompare

open System.Collections.Generic

type HighCardComare (allowSite : bool) = 
    let m_allowSite = allowSite

    interface IComparer<Cards.Card> with
        member this.Compare(x: Cards.Card, y: Cards.Card): int =
        
            let compare (x : int, y : int, higherWin : bool) : int =
                match x > y with
                | true -> 1
                | false -> 
                    match x < y with
                    | true -> - 1
                    | false -> 0

            match x with
                | Cards.WildCard -> 
                    match y with
                        | Cards.WildCard -> 0
                        | _ -> 1
                | Cards.StandardCard card_x ->
                    match y with
                        | Cards.WildCard -> - 1
                        | Cards.StandardCard card_y ->
                            match compare(card_x.Number, card_y.Number, true) with
                                | result when result <> 0 -> result
                                | _ -> 
                                    match m_allowSite with
                                        | true -> compare(card_x.Suit, card_y.Suit, false)
                                        | false -> 0

type HighCardMultipleCompare (singleCompare : IComparer<Cards.Card>) =

    let m_singleCompare = singleCompare

    interface IComparer<Cards.Card list> with
        member this.Compare(x: Cards.Card list, y: Cards.Card list): int = 

            let rec compare (x: Cards.Card list, y: Cards.Card list, singleCompare : IComparer<Cards.Card>, initIndex : int) : int =
                match initIndex > (x.Length - 1) with
                | true -> 0
                | false ->
                    match m_singleCompare.Compare(x[initIndex], y[initIndex]) with
                    | 0 -> compare (x, y, singleCompare, initIndex + 1)
                    | x -> x

            match (x.Length > y.Length) with
            | true -> 1
            | false ->
                match (x.Length < y.Length) with
                | true -> -1
                | false -> compare(x, y, m_singleCompare, 0)



    





