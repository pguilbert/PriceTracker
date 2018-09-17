namespace PriceTracker

module Library =
    open FSharp.Data
    open System.Net
    
    let getDocument url = 

        ///Handle System.Net.WebException to provide error details
        let rec (|ServerError|NetworkError|StatusCodeNotFound|UnknownError|) (ex:exn) = 
            match ex with
            | :? System.Net.WebException as webEx ->
                match webEx.Status with
                | WebExceptionStatus.ProtocolError -> 
                    match webEx.Response with
                    | :? HttpWebResponse as httpResponse -> 
                        match httpResponse.StatusCode with
                        | HttpStatusCode.NotFound -> StatusCodeNotFound
                        | _ -> ServerError
                    | _ -> 
                        match ex.InnerException with
                        | StatusCodeNotFound ex -> StatusCodeNotFound
                        | _ -> ServerError
                | _ -> NetworkError
            | _ -> UnknownError

        try 
            HtmlDocument.Load(url:string) |> Result.Ok 
        with
        | :? System.Net.WebException as ex -> 
            match ex with
            | StatusCodeNotFound -> Message.UrlNotFoundOnTheProviderServer |> Result.Error
            | NetworkError -> Message.NetworkError ex |> Result.Error
            | ServerError -> Message.GenericServerError ex |> Result.Error
            | _ -> Message.UnknownError ex |> Result.Error
        //Throw all other type of exception

