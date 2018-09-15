open System
open PriceTracker

let printAmazonPrice url = Amazon.getPrice url |> printf "%A \n"

[<EntryPoint>]
let main argv =
    let urls = 
        [|
            "https://www.google.com/"; //Error InvalidPriceProviderUrl
            "https://www.amazon.fr/"; //Error NoPriceFound;
            "https://www.amazon.fr/gp/product/B0756CYWWD";
            "https://www.amazon.com/dp/B01DFKC2SO";
            "https://www.amazon.ca/Holmes-Blizzard-7-Inch-Oscillating-Table/dp/B000J07RMU";
            "https://www.amazon.co.uk/Anglepoise-Original-1227-Desk-Lamp/dp/B01EN94J9G";
            "https://www.amazon.fr/Jabra-Speak-Haut-parleur-Bluetooth-Noir/dp/B00ANI7HI2";
            "https://www.amazon.fr/gp/product/1439148813";
            "https://www.amazon.fr/gp/product/B075CXJN6D/ref=crt_ewc_title_oth_1?ie=UTF8&psc=1&smid=A1X9LI0R1YTO2J";
        |]

    urls |> Array.iter printAmazonPrice 

    Console.Read() |> ignore
    0
