namespace PriceTracker

[<AutoOpen>]
module Types =

    type Message = 
        InvalidPriceProviderUrl 
        | NetworkError of string
        | NoPriceFound
