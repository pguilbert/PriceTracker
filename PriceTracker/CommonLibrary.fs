namespace PriceTracker

module CommonLibrary = 

    let optionToResult errorIfNone = 
        function
        | Some x -> Result.Ok x
        | None -> Result.Error errorIfNone

    // Try parse Float
    let (|Float|_|) str =
       match System.Double.TryParse(str) with
       | (true,float) -> Some(float)
       | _ -> None