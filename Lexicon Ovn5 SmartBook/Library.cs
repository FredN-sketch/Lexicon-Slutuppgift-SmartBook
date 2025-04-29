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
       
        internal void AddBook(Book book)
        {
            books.Add(book);
           
        }
        internal void RemoveBook(Book book) 
        {
            if (books.Remove(book))            
                book = null;        
        }
        internal IEnumerable<Book> GetBooks()
        {
            return books.ToArray();
        }
        internal Book QueryIsbn(string isbn)
        {
            Book book = books.FirstOrDefault(b => b.Isbn == isbn);
            return book;
        }
        internal List<Book> QueryTitle(string title)
        {          
            List<Book> list = books.Where(b => b.Title.ToString().ToLower().Contains(title.ToLower())).ToList();
            return list;
        }
        internal List<Book> QueryAuthor(string author)
        {            
            List<Book> list = books.Where(b => b.Author.ToString().ToLower().Contains(author.ToLower())).ToList();
            return list;
        }
    }
}
