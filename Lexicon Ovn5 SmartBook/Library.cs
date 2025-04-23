using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon_Slutuppgift_SmartBook
{
    class Library
    {
        public List<Book> books;
        public Library()
        {
            books = new List<Book>();
        }
        internal void AddBook(Book book)
        {
            books.Add(book);
        }
    }
}
