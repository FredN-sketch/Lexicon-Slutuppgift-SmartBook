using Lexicon_Slutuppgift_SmartBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Lexicon_Ovn5_SmartBook
{
    public static class LibraryApp
    {
        private static Library library = new Library();
        public static void Start()
        {
            //SeedData();
            bool showMenu = true;
            while (showMenu)
            {
                MenuHelper.PrintMenu();
                showMenu = MenuHelper.MainMenu();
            }
        }
        public static void AddBookWithPrompt()
        {            
            Console.Write("Titel: ");
            string title = Console.ReadLine();
            Console.Write("Författare: ");
            string author = Console.ReadLine();            
            

            string isbn = ValidateIsbn("ISBN");     

            Console.Write("Kategori: ");
            string category = Console.ReadLine();

            library.AddBook(new Book(title, author, isbn, category));
        }

        public static string ValidateIsbn(string prompt)
        {
            //ska nog ändra så att jag kollar IsNullOrWhiteSpace i en egen funktion som jag anropar från
            //denna för att uppnå bättre DRY
            bool success = false;
            string answer;

            do
            {
                Console.Write($"{prompt}: "); 
                answer = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(answer))
                {
                    Console.WriteLine($"Ange ett giltigt {prompt}");
                }
               
                else if (library.GetBooks().Any(b => b.Isbn == answer))
                {
                    Console.WriteLine("Det ISBN-numret används redan");
                }
                    
                else
                {
                    success = true;
                }

            } while (!success);

            return answer;
        }

        public static void SeedData()
        {
            library.AddBook(new Book("Bilbo", "Tolkien JRR", "91 29 53633 2", "Fantasy"));
            library.AddBook(new Book("Varulvens år", "King Stephen", "91-32-31333-0", "Skräck"));
            library.AddBook(new Book("Fågeln som vrider upp världen", "Murakami Haruki", "978-91-1-301940-6", "Roman"));
            library.AddBook(new Book("Staden som försvann", "King Stephen", "91-582-1002-4", "Skräck"));
            library.AddBook(new Book("Shogun", "Clavell James", "91-582-1002-5", "Roman"));
            library.AddBook(new Book("Moment 22", "Heller Joseph", "91-582-1002-6", "Roman"));
            library.AddBook(new Book("Den illustrerade mannen", "Bradbury Ray", "91-582-1002-8", "Science Fiction"));
            library.AddBook(new Book("Jag, robot", "Asimov Isaac", "91-582-1002-9", "Science Fiction"));
            library.AddBook(new Book("Boken som försvann", "Bertilsson Adam", "12312133", "Fiktion"));
            library.AddBook(new Book("Stora skräckboken", "King William", "12312134", "Skräck"));
            library.AddBook(new Book("The Fundamentals of Kyokushin Karate","Fitkin Brian","12346","Fack"));
            library.AddBook(new Book("Momo", "Ende Michael", "12312135", "Fantasy"));
            library.AddBook(new Book("Den oändliga historien", "Ende Michael", "12312136", "Fantasy"));
            library.AddBook(new Book("Den oländiga historien", "Kvist Kalle", "12312137", "Roman"));


        }
        public static void ListAllBooks()
        {
            var books = library.GetBooks()
          //  var booklist = books
                .OrderBy(x => x.Author)
                .ThenBy(x => x.Title);
            Console.WriteLine($"Författare \tTitel \t\t\tISBN \tKategori \tStatus");
            foreach (Book book in books)
            {
                //Console.WriteLine($"Författare: {book.Author}\tTitel: {book.Title}\t\t{book.Isbn}\t{book.Category}");
                //Console.WriteLine($"{book.Author} \t{book.Title} \t{book.Isbn} \t{book.Category} {book.Status}");
                Console.WriteLine(book);
            }
        }
        internal static void ExportLibraryToJson()
        {
            File.WriteAllText(@"C:\Tmp\library.json", JsonSerializer.Serialize(library.GetBooks()));
            Console.WriteLine("Exporten är klar");
            MenuHelper.PressAnyKey();
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

        internal static void JsonMenu()
        {
            Console.WriteLine("Spara och läsa in biblioteket från fil");
            Console.WriteLine("======================================");
            Console.WriteLine("1. Spara biblioteket till fil (exportera)");
            Console.WriteLine("2. Läs in biblioteket från fil (importera)");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    ExportLibraryToJson();                     
                    break;
                case "2":
                    ImportLibraryFromJson();
                    break;
                default:
                    Console.WriteLine("Ogiltigt val");
                    Console.ReadLine();
                    break;
            }                   
        }
        internal static void SearchMenu()
        {
            Console.WriteLine("Sök bok");
            Console.WriteLine("===============");
            Console.WriteLine("1. Författare");
            Console.WriteLine("2. Titel");
            Console.WriteLine("3. ISBN");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    string author = Validation.AskForString("Författare");
                    var list = library.QueryAuthor(author);
                    foreach (Book b in list)
                    {
                        //Console.WriteLine($"Författare: {book.Author}\tTitel: {book.Title}\t\t{book.Isbn}\t{book.Category}");
                        //Console.WriteLine($"{book.Author} \t{book.Title} \t{book.Isbn} \t{book.Category} {book.Status}");
                        Console.WriteLine(b);
                    }
                    break;
                case "2":
                    string title = Validation.AskForString("Titel");
                  //  Book book = library.QueryTitle(title);
                    list = library.QueryTitle(title);
                  //  Console.WriteLine(book);
                    foreach (Book b in list)
                    {
                        //Console.WriteLine($"Författare: {book.Author}\tTitel: {book.Title}\t\t{book.Isbn}\t{book.Category}");
                        //Console.WriteLine($"{book.Author} \t{book.Title} \t{book.Isbn} \t{book.Category} {book.Status}");
                        Console.WriteLine(b);
                    }
                    //   MenuHelper.PressAnyKey();
                    break;
                case "3":
                    string isbn = Validation.AskForString("isbn");
                    Book book = library.QueryIsbn(isbn);
                    Console.WriteLine(book);
                    break;
                default:
                    Console.WriteLine("Ogiltigt val");
              //      Console.ReadLine();
                    break;
            }
            MenuHelper.PressAnyKey();
        }
    }
}
