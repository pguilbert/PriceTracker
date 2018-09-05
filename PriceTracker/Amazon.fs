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

    let private getPriceFromHtmlDocumentForCssSelector cssSelector (doc:HtmlDocument) = 
        doc.CssSelect(cssSelector) 
                |> Seq.tryFind(fun _ -> true)
                |> function
                    | Some node -> node.InnerText() |> parseTextToFloat
                    | None -> None

    let private getDealPriceFromHtmlDocument (doc:HtmlDocument) = 
        getPriceFromHtmlDocumentForCssSelector "#priceblock_dealprice" doc
        |> function 
            | Some result -> Some result
            | None ->  
                getPriceFromHtmlDocumentForCssSelector "#priceblock_ourprice" doc
                |> function
                    | Some result -> Some result 
                    | None -> getPriceFromHtmlDocumentForCssSelector ".offer-price" doc
    
    let private getPriceInformationFromHtmlDocument (doc:HtmlDocument) = getDealPriceFromHtmlDocument doc
    let private getPriceForValidUrl url = (>>) getDocument getPriceInformationFromHtmlDocument url

    let getPrice url = 
        isAValidAmazonProductUrl url 
        |> function
            | true -> getPriceForValidUrl url
            | false -> None

