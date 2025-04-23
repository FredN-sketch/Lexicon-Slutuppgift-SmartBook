

using Lexicon_Slutuppgift_SmartBook;

namespace Lexicon_Ovn5_SmartBook
{
    internal class Program
    {
        private static Library library = new Library();
        static void Main(string[] args)
        {
            SeedData();
            bool showMenu = true;
            while (showMenu)
            {
                MenuHelper.PrintMenu();
                showMenu = MainMenu();
            }           
        }

        private static void SeedData()
        {
            library.AddBook(new Book("Bilbo", "Tolkien, J.R.R.", "ISBN 91 29 53633 2", "Fantasy"));
            library.AddBook(new Book("Varulvens år", "King, Stephen", "ISBN 91-32-31333-0", "Skräck"));
            library.AddBook(new Book("Fågeln som vrider upp världen", "Murakami, Haruki", "ISBN 978-91-1-301940-6", "Roman"));
            library.AddBook(new Book("Staden som försvann", "King, Stephen", "ISBN 91-582-1002-4", "Skräck"));

            throw new NotImplementedException();
        }

        private static bool MainMenu()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    return true;
                default:
                    return false;
            }
        }
    }
}
