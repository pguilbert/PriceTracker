namespace PriceTracker.Amazon


module Amazon = 
    open PriceTracker.Common
    open FSharp.Data
    open System.Text.RegularExpressions
 
    let private isAValidAmazonProductUrl (url:string) = url.StartsWith("https://www.amazon")

    let private (|Float|_|) str =
       match System.Double.TryParse(str) with
       | (true,float) -> Some(float)
       | _ -> None

    let private parseTextToFloat text =  
        Regex.Replace(text, "[^,0-9]+", "")
        |> function
            | Float f -> Some f
            | _ -> None

    let private tryGetInnerText cssSelector (doc:HtmlDocument) = 
        doc.CssSelect(cssSelector) 
        |> Seq.tryFind(fun _ -> true)
        |> Option.bind (fun node -> node.InnerText() |> Some)

    let private getDealPriceFromHtmlDocument (doc:HtmlDocument) = 
        tryGetInnerText "#priceblock_dealprice" doc
        |> Option.orElseWith (fun () -> tryGetInnerText "#priceblock_ourprice" doc)
        |> Option.orElseWith (fun () -> tryGetInnerText ".offer-price" doc)
        |> Option.bind parseTextToFloat
    
    let private getPriceInformationFromHtmlDocument (doc:HtmlDocument) = getDealPriceFromHtmlDocument doc
    let private getPriceForValidUrl url = (>>) getDocument getPriceInformationFromHtmlDocument url

    let getPrice url = 
        isAValidAmazonProductUrl url
        |> function
            | true -> getPriceForValidUrl url
            | false -> None

