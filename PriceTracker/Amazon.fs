namespace PriceTracker


module Amazon =
    open PriceTracker.CommonLibrary
    open PriceTracker.Library
    open FSharp.Data
    open System.Text.RegularExpressions
    open PriceTracker
 
    let private isAValidAmazonProductUrl (url:string) = url.StartsWith("https://www.amazon")

    let private parsePriceTextToFloat text =  
        Regex.Replace(text, "[^,0-9]+", "")
        |> function
            | Float f -> Some f
            | _ -> None

    let private tryGetInnerText cssSelector (doc:HtmlDocument) = 
        doc.CssSelect(cssSelector) 
        |> Seq.tryFind(fun _ -> true)
        |> Option.bind (fun node -> node.InnerText() |> Some)

    let private lookupForPriceInDocument (doc:HtmlDocument) = 
        tryGetInnerText "#priceblock_dealprice" doc
        |> Option.orElseWith (fun () -> tryGetInnerText "#priceblock_ourprice" doc)
        |> Option.orElseWith (fun () -> tryGetInnerText ".offer-price" doc)
        |> Option.bind parsePriceTextToFloat

    let private lookupForPriceInDocumentResult doc = 
        lookupForPriceInDocument doc |> optionToResult Message.NoPriceFound 

    let private getPriceForValidUrl = getDocument >> (Result.bind lookupForPriceInDocumentResult)

    let getPrice url = 
        isAValidAmazonProductUrl url
        |> function
            | true -> getPriceForValidUrl url
            | false -> Message.InvalidPriceProviderUrl |> Result.Error

