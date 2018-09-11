module Tests

open Xunit
open PriceTracker

[<Fact>]
let ``When URL is wrong expect InvalidPriceProviderUrl``() =
    Assert.Equal(Result.Error(Message.InvalidPriceProviderUrl), Amazon.getPrice "http://google.com")

[<Fact>]
let ``When provider URL is ok but not a product page expect NoPriceFound``() =
    Assert.Equal(Result.Error(Message.NoPriceFound), Amazon.getPrice "https://www.amazon.fr/")

[<Fact>]
let ``When URL is ok expect price``() =
    let test = 
        Amazon.getPrice "https://www.amazon.fr/gp/product/B0756CYWWD" 
        |> function
            | Result.Ok _ -> true
            | Result.Error _ -> false
    Assert.True(test)