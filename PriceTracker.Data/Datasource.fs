namespace PriceTracker.Data

module Datasource = 
    open PriceTracker

    let getSavedProducts =
        [|
            {Id="EAF236FD-4349-47A2-B32F-85C21D9E06CA"; Label="Not Found"; Urls=[|"https://www.google.com/" |]};
            {Id="68EB1063-6C69-4333-B0EF-D22576819E21"; Label="Not Found"; Urls=[|"https://www.amazon.fr/" |]};
            {Id="05B4856A-5930-42A9-9E46-F3A56F2D6096"; Label="Not Found"; Urls=[|"https://www.amazon.fr/flmdjsfljfgdsf" |]};
            {Id="8C206F3A-AD38-44C6-95C5-F9E05ED5FB5D"; Label="Bose Casque sans fil à réduction de bruit QuietComfort 35 II"; Urls=[|"https://www.amazon.fr/gp/product/B0756CYWWD" |]};
            {Id="C64ED247-D1EC-4113-816D-D15D712707D5"; Label="Echo Dot (2nd Generation) - Smart speaker with Alexa - Black"; Urls=[|"https://www.amazon.com/dp/B01DFKC2SO" |]};
            {Id="127CF861-B4DD-42A8-AD91-B681F9DD0DCA"; Label="Holmes Lil' Blizzard 7-Inch Oscillating Table Fan"; Urls=[|"https://www.amazon.ca/Holmes-Blizzard-7-Inch-Oscillating-Table/dp/B000J07RMU" |]};
            {Id="8DFD1500-4C2B-4642-9AFA-1ED64258214F"; Label="Anglepoise Original 1227 Desk Lamp - Linen White"; Urls=[|"https://www.amazon.co.uk/Anglepoise-Original-1227-Desk-Lamp/dp/B01EN94J9G" |]};
            {Id="0CFCCB14-8029-42A5-A0AC-7718707A33B7"; Label="Jabra - Speak 510"; Urls=[|"https://www.amazon.fr/Jabra-Speak-Haut-parleur-Bluetooth-Noir/dp/B00ANI7HI2" |]};
            {Id="15279DA2-B24B-42DA-B595-A1B4D13331FE"; Label="Failure Is Not an Option"; Urls=[|"https://www.amazon.fr/gp/product/1439148813" |]};
            {Id="E226888F-5D48-457B-87BF-500FDD26164C"; Label="SnowCinda Bracelet pour Fitbit Alta "; Urls=[|"https://www.amazon.fr/gp/product/B075CXJN6D/ref=crt_ewc_title_oth_1?ie=UTF8&psc=1&smid=A1X9LI0R1YTO2J" |]};
            {Id="13BD30B8-78D5-47FD-9F9C-1D38ACB95EFE"; Label="Fire TV Stick | Basic Edition"; Urls=[|"https://www.amazon.fr/gp/product/B01ETRGE7M" |]};
        |]

    let saveNewProduct (product:Product) = ()


