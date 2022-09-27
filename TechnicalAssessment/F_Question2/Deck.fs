module Deck

exception NoCardAvailableExpection  

type IDeck = 
    abstract member GetCard : Cards.Card

type CustomDeck (suitsNumber : int, cardPerSuit : int, wildCardNumber : int, deckNumber : int) = 
    let m_suitsNumber = suitsNumber
    let m_cardPerSuit = cardPerSuit
    let m_wildCardNumber = wildCardNumber
    let m_deckNumber = deckNumber

    let cardPerDeck = m_suitsNumber * m_cardPerSuit + m_wildCardNumber
    let cardCount = cardPerDeck * m_deckNumber

    let mutable m_availableNumber : int list = []

    do 
        m_availableNumber <- [for i in 0 .. cardCount -> i]

    interface IDeck with
        member this.GetCard: Cards.Card = 

            let generateRandom(minVal : int, maxVale : int) : int = 
                let random = new System.Random()
                random.Next(minVal, maxVale);

            let createCard (cardInt : int) : Cards.Card =
                let numberInDeck = cardInt % cardPerDeck
                match numberInDeck >= m_suitsNumber * m_cardPerSuit with
                | true -> Cards.WildCard
                | false -> 
                    let card : Cards.StandardCard = { 
                            Number = numberInDeck % m_cardPerSuit 
                            Suit = numberInDeck / m_cardPerSuit
                            }
                    Cards.Card.StandardCard card
                    

            match m_availableNumber with
            | [] -> raise NoCardAvailableExpection
            | current -> 
                let randomNumer = generateRandom(0, current.Length - 1)
                let indexed = current |> List.indexed
                m_availableNumber <- indexed |> List.filter (fun (i, _) -> i <> randomNumer) |> List.map snd
                indexed[randomNumer] |> snd |> createCard
