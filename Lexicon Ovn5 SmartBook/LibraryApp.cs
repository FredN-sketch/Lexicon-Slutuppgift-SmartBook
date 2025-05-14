using Lexicon_Slutuppgift_SmartBook;
using System.Text.Json;

namespace Lexicon_Ovn5_SmartBook
{
    public static class LibraryApp
    {
        private static Library library = new Library();       
        public static void Start()
        {
            InitiateBookReportHeader();
            bool showMenu = true;
            while (showMenu)
            {
                MenuHelper.PrintMenu();
                showMenu = MenuHelper.MainMenu();
            }
        }

        private static void InitiateBookReportHeader()
        {
            Book.BookReportHeader.Append("Författare".PadRight(20) + "\t");
            Book.BookReportHeader.Append("Titel".PadRight(36) + "\t");
            Book.BookReportHeader.Append("ISBN".PadRight(15) + "\t");
            Book.BookReportHeader.Append("Kategori".PadRight(15) + "\t");
            Book.BookReportHeader.Append("Status".PadRight(20) + "\t");
            Book.BookReportHeader.Append(Environment.NewLine);
            Book.BookReportHeader.Append("".PadRight(20 + 36 + 15 + 15 + 21, '='));         
        }

        public static void AddBookWithPrompt()
        {        
            Console.Write(Environment.NewLine);
            Console.WriteLine("Lägg till en bok");
            Console.Write(Environment.NewLine);
            string title = Validation.AskForString("Titel");            
            string author = Validation.AskForString("Författare");
            string isbn = ValidateIsbn();
            string category = Validation.AskForString("Kategori");
            library.AddBook(new Book(title, author, isbn, category));
            Console.WriteLine();
            Console.WriteLine("Boken är tillagd");      
        }

        public static string ValidateIsbn()
        {
            bool success = false;
            string answer;

            do
            {
                Console.Write($"ISBN: "); 
                answer = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(answer))
                {
                    Console.WriteLine($"Ange ett giltigt ISBN");
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
            library.AddBook(new Book("Fågeln som vrider upp världen", "Murakami Haruki", "978-91-13019-6", "Roman"));
            library.AddBook(new Book("Staden som försvann", "King Stephen", "91-582-1002-4", "Skräck"));
            library.AddBook(new Book("Shogun", "Clavell James", "91-582-1002-5", "Roman"));
            library.AddBook(new Book("Moment 22", "Heller Joseph", "91-582-1002-6", "Roman"));
            library.AddBook(new Book("Den illustrerade mannen", "Bradbury Ray", "91-582-1002-8", "Science Fiction"));
            library.AddBook(new Book("Jag, robot", "Asimov Isaac", "91-582-1002-9", "Science Fiction"));
            library.AddBook(new Book("Boken som försvann", "Bertilsson Adam", "12312133", "Fiktion"));
            library.AddBook(new Book("Stora skräckboken", "King William", "12312134", "Skräck"));
            library.AddBook(new Book("The Fundamentals of Kyokushin Karate","Fitkin Brian","12346","Fack"));
            library.AddBook(new Book("Momo", "Ende Michael", "12345", "Fantasy"));
            library.AddBook(new Book("Den oändliga historien", "Ende Michael", "12348", "Fantasy"));
            library.AddBook(new Book("Den oländiga historien", "Kvist Kalle", "12347", "Roman"));
            Console.WriteLine("Data inläst.");            
        }
        public static void ListAllBooks()
        {
            var books = library.GetBooks()          
                .OrderBy(x => x.Author)
                .ThenBy(x => x.Title);
            Console.WriteLine();
            Console.WriteLine(Book.BookReportHeader.ToString());
            foreach (Book book in books)
            {                
                Console.WriteLine(book);
            }
        }
        internal static void ExportLibraryToJson()
        {
            File.WriteAllText(@"C:\Tmp\library.json", JsonSerializer.Serialize(library.GetBooks()));
            Console.WriteLine("Exporten är klar");            
        }
        internal static void ImportLibraryFromJson()
        {
            string fileName = @"C:\Tmp\library.json";
            //   var books = JsonSerializer.Deserialize<Object>(File.ReadAllText(@"C:\Tmp\library.json"));
            try
            {
                string jsonString = File.ReadAllText(fileName);
                var booklist = JsonSerializer.Deserialize<List<Book>>(jsonString);
                foreach (Book book in booklist)
                {
                    library.AddBook(book);
                }
                Console.WriteLine("Importen är klar");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Det finns ingen JSON-fil att läsa in biblioteket från.");
                Console.WriteLine("Lägg in böcker manuellt eller använd SeedData, och exportera till JSON först.");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType().ToString());                
            }
                       
        }

        internal static void JsonMenu()
        {
            Console.WriteLine("Spara och läsa in biblioteket från fil");
            Console.WriteLine("======================================");
            Console.WriteLine("1. Spara biblioteket till fil (exportera)");
            Console.WriteLine("2. Läs in biblioteket från fil (importera)");
            string userInput = Validation.AskForString("", ["1","2"]);
            switch (userInput)
            {
                case "1":
                    ExportLibraryToJson();                     
                    break;
                case "2":
                    ImportLibraryFromJson();
                    break;
                default:                    
                    break;
            }                   
        }
        internal static void SearchMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Sök bok");
            Console.WriteLine("===============");
            Console.WriteLine("1. Författare");
            Console.WriteLine("2. Titel");
            Console.WriteLine("3. ISBN");
            Console.WriteLine();
            string userInput = Validation.AskForString("", ["1", "2", "3"]);
            Console.WriteLine();
            switch (userInput)
            {
                case "1":
                    string author = Validation.AskForString("Författare");
                    var list = library.QueryAuthor(author)
                        .OrderBy(x => x.Author)
                        .ThenBy(x => x.Title).ToList(); 
                    QueryResultList(list);
                    break;
                case "2":
                    string title = Validation.AskForString("Titel");                 
                    list = library.QueryTitle(title)
                         .OrderBy(x => x.Author)
                         .ThenBy(x => x.Title).ToList(); 
                    QueryResultList(list);                    
                    break;
                case "3":
                    string isbn = Validation.AskForString("ISBN");
                    Console.WriteLine();
                    Book book = library.QueryIsbn(isbn); //ISBN ska vara unikt, högst en sökträff
                    if (book == null)
                        Console.WriteLine("Sökningen gav inget resultat.");
                    else
                    {                        
                        Console.WriteLine(Book.BookReportHeader);
                        Console.WriteLine(book);
                        BookMethods(book);
                    }                    
                    break;
                default:                           
                    break;
            }       
        }

        private static void QueryResultList(List<Book> list)
        {
            if (list.Count == 0)
                Console.WriteLine("Sökningen gav inget resultat.");
            else if (list.Count == 1)
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine(Book.BookReportHeader); 
                Console.WriteLine(list[0]);
                Console.Write(Environment.NewLine);
                BookMethods(list[0]);
            }
            else
                BookListMenu(list);
        }

        private static void BookListMenu(List <Book> list)
        {
            Console.Write(Environment.NewLine);
            Console.WriteLine(Book.BookReportHeader);
            foreach (Book b in list)
            {               
                Console.WriteLine($"{list.IndexOf(b) + 1} {b}"); //+1 då jag inte vill börja med radnr 0 i listan
            }
            Console.Write(Environment.NewLine);
           
            int listCount = list.Count+1; 
            uint[] uints = new uint[listCount]; //array av giltiga val som parameter till AskForUint
            for (int i = 0; i < listCount; i++)
            {
                uints[i] = (uint)i;              
            }
            
            Console.WriteLine("Ange radnr för den bok du vill välja eller 0 för att avbryta");
            uint input = Validation.AskForUInt("Radnr", uints);
            int index = (int)(input - 1);
            
            if (input <= list.Count && input != 0)
            {
                Book book = list[index];
                BookMethods(book);
            }
        }

        private static void BookMethods(Book book)
        {
            Console.WriteLine();
            Console.WriteLine("1. Markera bok som utlånad eller tillgänglig");
            Console.WriteLine("2. Ta bort bok");
            Console.WriteLine("0. Avbryt");
            string input = Validation.AskForString("", ["1", "2", "0"]);
            switch (input)
            {
                case "1":
                    ChangeBookStatus(book);                                   
                    break;
                case "2":
                    RemoveBook(book);                                       
                    break;
                case "0":
                    break;
                default: 
                    break;
            }
        }

        private static void RemoveBook(Book book)
        {
            Console.WriteLine($"Du har angett att du vill ta bort \"{book.Title}\" av {book.Author}");
            string input = Validation.AskForString("Är du säker? j/n", ["j", "n"]);
            switch (input)
            {
                case "j":
                    library.RemoveBook(book);
                    Console.WriteLine("Boken är borttagen");
                    break;
                case "n":
                    break;
                default:                
                    break;
            }                     
        }

        private static void ChangeBookStatus(Book book)
        {
            Console.WriteLine($"Boken är markerad som {book.Status}");
            string input = Validation.AskForString("Vill du ändra? j/n", ["j", "n"]);
            switch (input) 
            {
                case "j":
                    if (book.Status == BookStatus.Utlånad)
                        book.Status = BookStatus.Tillgänglig;
                    else
                        book.Status = BookStatus.Utlånad;
                    break;
                case "n":
                    break;
                default:                   
                    break;
            }
            Console.WriteLine($"\"{book.Title}\" av {book.Author} är {book.Status}");      
        }
    }
}
