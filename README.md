# Musikbibliotek

## Introduktion
Ett Web-API som hanterar ett musikbibliotek. Det ska finnas funktionalitet för att kunna lägga till nya sånger, album och artister. Det ska också finnas möjlighet att hämta alla sorters data, specifika data, det ska gå att uppdatera och ta bort existerande data. Eran lösning får gärna använda ”Swagger” som ”klient” och för testning. PostMan är ett annat lämpligt verktyg om ni hellre vill göra det. Kom ihåg att meddela vid inlämning vilket verktyg ni nyttjat.

### Följande domän-modeller ska finnas:

* Artist: Ska innehålla ID, namn och hur många album artisten har.
* Album: Ska innehålla ID, namn, vilken artist som gjort den, och hur många sånger som finns.
* Song: Ska innehålla ID, namn, längd, vilket album den tillhör och vilken artist som gjort den.

## Funktionalitet
* När man skapar en ny artist, så ska endast artistnamn skickas in, och ett objekt med namnet och det tilldelade ID’et skickas tillbaka.
* När man skapar ett nytt album, så ska endast albumnamn och artist-ID skickas in, och ett objekt med albumnamn och det tilldelade ID’et skickas tillbaka.
* När man skapar en ny sång, så ska endast sångnamn, längd och album-ID skickas in, och ett objekt med sångnamn och det tilldelade ID’et skickas tillbaka. 

* När man hämtar ut en artist via API så ska artistens ID och namn, och en lista på samtliga album-namn och deras IDn hämtas ut returneras som svar.
* När man hämtar ut ett album via API så ska albumets ID och namn, artistens namn och ID, och en lista över samtliga låt-namn och deras IDn returneras.
* När man hämtar ut en sång via API så ska sångens namn, längd och ID, artistens namn och ID, och albumets namn och ID returneras.
 

* När man tar bort en artist så ska även dess associerade album och deras sånger tas bort, och när man tar ett album ska dess sånger också tas bort.
  * Däremot ska en artist inte tas bort om man tar bort ett album, och ett album inte tas bort om man tar bort en sång.
  * Tas ett album bort måste antalet album uppdateras hos artisten
  * Tas en sång bort måste antalet sånger uppdateras hos albumet

## Krav
* Programmet ska ha separata API-kontrollers för varje modell, med full CRUD-uppsättning för varje kontroller och modell.
* Programmet ska ha separata API-lager (endpoints), servicelager (logik) och datalager (persistens), och ha god uppdelning av ansvar emellan.
* Ett album får inte läggas till för en artist som inte existerar.
* En sång får inte läggas till för ett album som inte existerar
* Programmet ska ha någon slags persistens, alltså data ska sparas mellan körningar. Fritt val hur denna persistens implementeras.
* Programmet ska ha god felhantering, görs felaktiga inmatningar ska lämplig respons-status och meddelande returneras till användaren.
 
