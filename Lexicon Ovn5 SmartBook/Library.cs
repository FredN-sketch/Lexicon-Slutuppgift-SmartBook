using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        internal void AddBook(Book book)
        {
            books.Add(book);
        }
        internal void RemoveBook(Book book) { }
        internal IEnumerable<Book> GetBooks()
        {
            return books.ToArray();
        }
    }
}
