namespace PriceTracker

module Common = 
    open FSharp.Data

    type Message = 
        InvalidPriceProviderUrl 
        | NetworkError of string
        | NoPriceFound
    
    let getDocument url = 
        try 
            HtmlDocument.Load(url:string) |> Result.Ok 
        with
        | _ex -> Message.NetworkError _ex.Message |> Result.Error

    let optionToResult errorIfNone = 
        function
        | Some x -> Result.Ok x
        | None -> Result.Error errorIfNone

    // Try parse Float
    let (|Float|_|) str =
       match System.Double.TryParse(str) with
       | (true,float) -> Some(float)
       | _ -> None