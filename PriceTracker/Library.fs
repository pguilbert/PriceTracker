namespace PriceTracker

module Library =
    open FSharp.Data

    let getDocument url = 
        try 
            HtmlDocument.Load(url:string) |> Result.Ok 
        with
        | _ex -> Message.NetworkError _ex.Message |> Result.Error

