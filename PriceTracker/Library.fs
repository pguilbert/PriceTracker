namespace PriceTracker

module Common = 
    open FSharp.Data
    
    let getDocument url = HtmlDocument.Load(url:string)
