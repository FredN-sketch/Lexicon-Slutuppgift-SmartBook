# Lexicon Slutuppgift SmartBook

SmartBook Bibliotekssystem
==========================
1. Lägg till en bok (titel, författare, ISBN, kategori)
2. Lägg till flera böcker (SeedData)
3. Lista alla böcker 
4. Sök och hantera bok (via titel, författare eller ISBN)
5. Spara och läsa in biblioteket från fil (JSON)
0. Avsluta (det ska egentligen stå 0 och inte 6 till vänster om det här menyvalet men det verkar vara autonumrering i läsläget)

Använd funktion 2 i huvudmenyn om du inte vill knappa in böcker manuellt.
Jag har lagt in författarnas namn som “Efternamn Förnamn” i SeedData och i min JSON-fil för att underlätta sortering vid utskrift.
När det gäller felhantering/validering använder jag bara try/catch vid läsning av biblioteket från JSON. I menyvalen använder jag valideringsmetoder som tar en array med giltiga val som parameter.
Sökning på titel och författare är inte case sensitive och behöver inte vara exakt, dvs det går bra att söka på en del av titeln eller författarens namn. Sökning på ISBN måste dock vara exakt.

I testprojektet finns tre tester.
1. AddBook_ShouldAddBookToList
2. AddAndRemoveBook_ShouldAddAndRemoveBookToList
3. AddBookAndTestQueries

Det första testet lägger till en bok och verifierar att boken finns i biblioteket.
Det andra testet gör samma som det första, men tar sedan bort boken och verifierar att boken inte finns kvar i biblioteket.
Det tredje testet lägger till samma bok igen, och testar sedan metoderna för att söka boken via författare, titel och ISBN.

