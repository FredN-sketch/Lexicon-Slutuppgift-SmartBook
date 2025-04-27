using Lexicon_Slutuppgift_SmartBook;

namespace Lexicon_Ovn5_SmartBook
{
    public static class MenuHelper
    {
        public static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("SmartBook Bibliotekssystem");
            Console.WriteLine("==========================");
            Console.WriteLine("1. Lägg till en bok (titel, författare, ISBN, kategori)");
            Console.WriteLine("2. Ta bort en bok (via titel eller ISBN)");
            Console.WriteLine("3. Lista alla böcker");
            Console.WriteLine("4. Sök efter bok (titel eller författare)");
            Console.WriteLine("5. Markera bok som \"utlånad\" eller \"tillgänglig\"");
            Console.WriteLine("6. Spara och läsa in biblioteket från fil (JSON)");
            Console.WriteLine("7. SeedData");
            Console.WriteLine("0. Avsluta");
            Console.Write(Environment.NewLine);
            Console.WriteLine("Skriv in siffran till vänster om ett menyval för att köra resp funktion");
            Console.Write(Environment.NewLine);
        }
        public static bool MainMenu()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    LibraryApp.AddBookWithPrompt();
                    return true;
                case "2":
                    return true;
                case "3": 
                    LibraryApp.ListAllBooks();
                    PressAnyKey();
                    return true;
                case "4":
                    LibraryApp.SearchMenu();
                    return true;
                case "5":
                    return true;
                case "6":
                    LibraryApp.JsonMenu();                   
                    return true;
                case "7":
                    LibraryApp.SeedData();
                    return true;
                case "0":
                    return false;
                default:
                    Console.WriteLine("Ogiltigt val.");
                    PressAnyKey();
                    return true;
            }
        }

        public static void PressAnyKey()
        {
            Console.Write(Environment.NewLine);
            Console.WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn.");
            Console.ReadKey();
        }

    }
}
