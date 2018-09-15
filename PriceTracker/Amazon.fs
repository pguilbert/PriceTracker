namespace PriceTracker


module Amazon =
    open PriceTracker.CommonLibrary
    open PriceTracker.Library
    open FSharp.Data
    open System.Text.RegularExpressions
    open PriceTracker
    open System.Globalization
 
    let private isAValidAmazonProductUrl (url:string) = url.StartsWith("https://www.amazon")

    //See the link bellow to complete this list:
    //https://docs.microsoft.com/fr-fr/dotnet/api/system.globalization.regioninfo.isocurrencysymbol?redirectedfrom=MSDN&view=netframework-4.7.2#System_Globalization_RegionInfo_ISOCurrencySymbol
    let private getCurrencyCode (txt:string) =
        match txt with
        | x when x.Contains("EUR") -> "EUR"
        | x when x.Contains("CDN$") -> "CAD"
        | x when x.Contains("$") -> "USD"
        | x when x.Contains("£") -> "GBP"
        | x -> x

    let private parsePriceTextToPrice text =  
        let currency = getCurrencyCode text

        Regex.Replace(text, "[^,0-9.]+", "")
        |> parseWithCurrencyCode currency
        |> Option.bind (fun x -> Some { Value= x; Currency= currency})
        

    let private tryGetInnerText cssSelector (doc:HtmlDocument) = 
        doc.CssSelect(cssSelector) 
        |> Seq.tryFind(fun _ -> true)
        |> Option.bind (fun node -> node.InnerText() |> Some)

    let private lookupForPriceInDocument (doc:HtmlDocument) = 
        tryGetInnerText "#priceblock_dealprice" doc
        |> Option.orElseWith (fun () -> tryGetInnerText "#priceblock_ourprice" doc)
        |> Option.orElseWith (fun () -> tryGetInnerText ".offer-price" doc)
        |> Option.bind parsePriceTextToPrice

    let private lookupForPriceInDocumentResult doc = 
        lookupForPriceInDocument doc |> optionToResult Message.NoPriceFound 

    let private getPriceForValidUrl = getDocument >> (Result.bind lookupForPriceInDocumentResult)

    let getPrice url = 
        isAValidAmazonProductUrl url
        |> function
            | true -> getPriceForValidUrl url
            | false -> Message.InvalidPriceProviderUrl |> Result.Error

