module Cards

type StandardCard = { Number : int; Suit : int }

//type WildCard = WildCard of string

type Card =
    | StandardCard of StandardCard
    | WildCard
