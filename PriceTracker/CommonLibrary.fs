namespace PriceTracker



module CommonLibrary = 
    open System.Globalization
    open FSharp.Data.Runtime.WorldBank
    
    let optionToResult errorIfNone = 
        function
        | Some x -> Result.Ok x
        | None -> Result.Error errorIfNone

    let parseWithCurrencyCode currencyCode str = 
        let parsingCulture = 
            CultureInfo.GetCultures(CultureTypes.SpecificCultures)
            |> Array.find (fun c -> ((new RegionInfo(c.LCID)).ISOCurrencySymbol) = currencyCode)
        
        System.Double.TryParse(str, NumberStyles.AllowDecimalPoint ||| NumberStyles.AllowThousands, parsingCulture)
        |> function
        | (true,float) -> Some(float)
        | _ -> None



