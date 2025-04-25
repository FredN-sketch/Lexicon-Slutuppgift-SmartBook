using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lexicon_Slutuppgift_SmartBook
{
    public class Library
    {
        private List<Book> books;
        public Library()
        {
            books = new List<Book>();
        }
        public void AddBookWithPrompt()
        {
            Console.WriteLine("Författare: ");
            string author = Console.ReadLine(); // The exclamation mark is the null-forgiving operator and just tells the
                                                // compiler to supress the nullable warnings. See: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-forgiving

            Console.WriteLine("Titel: ");
            string title = Console.ReadLine();

            Console.WriteLine("ISBN: ");
            string isbn = Console.ReadLine();
            // check for duplicate ISBN here

            Console.WriteLine("Kategori: ");
            string category = Console.ReadLine();

            AddBook(new Book(author, title, isbn, category));
           
        }
        internal void AddBook(Book book)
        {
            books.Add(book);
        }
        internal void RemoveBook(Book book) 
        { 
            books.Remove(book);
            Console.ReadLine();
            AddBook(book);
        }
        internal IEnumerable<Book> GetBooks()
        {
            return books.ToArray();
        }
        
    }
}
