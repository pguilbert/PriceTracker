namespace PriceTracker

[<AutoOpen>]
module Types =

    type Message = 
        | NoPriceFound
        | InvalidPriceProviderUrl 
        | UrlNotFoundOnTheProviderServer
        | NetworkError of exn
        | GenericServerError of exn
        | UnknownError of exn

    type Price = { 
        Value:float; 
        Currency:string;
    }

