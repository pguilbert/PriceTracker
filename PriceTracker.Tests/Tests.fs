module Tests

open Xunit
open PriceTracker

let wrongDomainUrl = "http://google.com"
let unableToExtractProductUrl = "https://www.amazon.fr/"
let notFoundValidUrl = "https://www.amazon.fr/flmdjsfljfgdsf"
let okUrl = "https://www.amazon.fr/gp/product/B0756CYWWD"

[<Fact>]
let ``When URL is wrong expect InvalidPriceProviderUrl``() =
    Assert.Equal(Result.Error(Message.InvalidPriceProviderUrl), Amazon.getPrice wrongDomainUrl)

[<Fact>]
let ``When provider URL is ok but not a product page expect NoPriceFound``() =
    Assert.Equal(Result.Error(Message.NoPriceFound), Amazon.getPrice unableToExtractProductUrl)

[<Fact>]
let ``When provider URL domain is ok but the page is not found expect UrlNotFoundOnTheProviderServer``() =
    Assert.Equal(Result.Error(Message.UrlNotFoundOnTheProviderServer), Amazon.getPrice notFoundValidUrl)

[<Fact>]
let ``When URL is ok expect price``() =
    let test = 
        Amazon.getPrice okUrl 
        |> function
            | Result.Ok _ -> true
            | Result.Error _ -> false
    Assert.True(test)