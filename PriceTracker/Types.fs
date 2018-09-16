namespace PriceTracker

[<AutoOpen>]
module Types =

    type Message = 
        InvalidPriceProviderUrl 
        | UrlNotFoundOnTheProviderServer
        | GenericServerError
        | NetworkError of string
        | NoPriceFound
        | UnknownError of exn

    type Price = { Value:float ; Currency:string }

