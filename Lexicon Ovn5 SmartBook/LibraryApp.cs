using Lexicon_Slutuppgift_SmartBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lexicon_Ovn5_SmartBook
{
    public static class LibraryApp
    {
        private static Library library = new Library();
        public static void Start()
        {
         //   SeedData();
            bool showMenu = true;
            while (showMenu)
            {
                MenuHelper.PrintMenu();
                showMenu = MenuHelper.MainMenu();
            }
        }
        private static void SeedData()
        {
            library.AddBook(new Book("Bilbo", "Tolkien, J.R.R.", "ISBN 91 29 53633 2", "Fantasy"));
            library.AddBook(new Book("Varulvens år", "King, Stephen", "ISBN 91-32-31333-0", "Skräck"));
            library.AddBook(new Book("Fågeln som vrider upp världen", "Murakami, Haruki", "ISBN 978-91-1-301940-6", "Roman"));
            library.AddBook(new Book("Staden som försvann", "King, Stephen", "ISBN 91-582-1002-4", "Skräck"));            
        }
       public static void ListAllBooks()
        {
            var books = library.GetBooks()
          //  var booklist = books
                .OrderBy(x => x.Author)
                .ThenBy(x => x.Title);
            Console.WriteLine($"Författare \tTitel \tISBN \tKategori");
            foreach (Book book in books)
            {
                //Console.WriteLine($"Författare: {book.Author}\tTitel: {book.Title}\t\t{book.Isbn}\t{book.Category}");
                Console.WriteLine($"{book.Author} \t\t{book.Title} \t{book.Isbn} \t{book.Category}");
            }
        }
        internal static void ExportLibraryToJson()
        {
            File.WriteAllText(@"C:\Tmp\library.json", JsonSerializer.Serialize(library.GetBooks()));
        }
        internal static void ImportLibraryFromJson()
        {
            string fileName = @"C:\Tmp\library.json";
            //   var books = JsonSerializer.Deserialize<Object>(File.ReadAllText(@"C:\Tmp\library.json"));
            string jsonString = File.ReadAllText(fileName);
            var booklist = JsonSerializer.Deserialize<List<Book>>(jsonString);
            foreach (Book book in booklist)
            {
                library.AddBook(book);
            }
            Console.WriteLine("Importen är klar");
            MenuHelper.PressAnyKey();
            
        }
    }
}
