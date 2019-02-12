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

    type Product = {
        Id:string;
        Label:string;
        Urls:string[];
    }


