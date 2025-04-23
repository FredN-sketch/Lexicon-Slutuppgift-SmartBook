using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon_Slutuppgift_SmartBook
{
    internal class Book
    {
        private string title;
        private string author;
        private string isbn;
        private string category;
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public string Category { get; set; }
        public Book(string title, string author, string isbn, string category)
        {
            Title = title;
            Author = author;
            Isbn = isbn;
            Category = category;                
        }

    }
}
