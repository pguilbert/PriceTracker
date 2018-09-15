namespace PriceTracker

[<AutoOpen>]
module Types =

    type Message = 
        InvalidPriceProviderUrl 
        | NetworkError of string
        | NoPriceFound

    type Price = { Value:float ; Currency:string }

