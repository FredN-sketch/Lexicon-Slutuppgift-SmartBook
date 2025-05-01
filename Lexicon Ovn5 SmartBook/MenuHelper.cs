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
            Console.WriteLine("2. Lägg till flera böcker (SeedData)");
            Console.WriteLine("3. Lista alla böcker");
            Console.WriteLine("4. Sök och hantera bok (via titel, författare eller ISBN)");
            Console.WriteLine("5. Spara och läsa in biblioteket från fil (JSON)");           
            Console.WriteLine("0. Avsluta");
            Console.Write(Environment.NewLine);
            Console.WriteLine("Skriv in siffran till vänster om ett menyval för att köra resp funktion");
            Console.Write(Environment.NewLine);
        }
        public static bool MainMenu()
        {
            string userInput = Validation.AskForString("", ["1", "2", "3", "4", "5", "0"]);
            switch (userInput)
            {
                case "1":
                    LibraryApp.AddBookWithPrompt();                    
                    PressAnyKey();
                    return true;
                case "2":
                    LibraryApp.SeedData();
                    PressAnyKey();
                    return true;
                case "3": 
                    LibraryApp.ListAllBooks();
                    PressAnyKey();
                    return true;
                case "4":
                    LibraryApp.SearchMenu();
                    PressAnyKey();
                    return true;
                case "5":
                    LibraryApp.JsonMenu();
                    PressAnyKey();
                    return true;               
                case "0":
                    return false;
                default:                    
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
