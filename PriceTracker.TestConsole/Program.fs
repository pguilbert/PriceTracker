open System
open PriceTracker.Amazon

let printAmazonPrice url = Amazon.getPrice url |> printf "%A \n"

[<EntryPoint>]
let main argv =

    printAmazonPrice "https://www.amazon.fr/Jabra-Speak-Haut-parleur-Bluetooth-Noir/dp/B00ANI7HI2"
    printAmazonPrice "https://www.amazon.fr/gp/product/1439148813"
    printAmazonPrice "https://www.amazon.fr/gp/product/0857501003"
    printAmazonPrice "https://www.amazon.fr/gp/product/B075CXJN6D/ref=crt_ewc_title_oth_1?ie=UTF8&psc=1&smid=A1X9LI0R1YTO2J"

    Console.Read() |> ignore
    0
