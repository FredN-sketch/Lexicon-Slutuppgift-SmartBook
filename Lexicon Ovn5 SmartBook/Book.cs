using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Lexicon_Slutuppgift_SmartBook
{
    internal class Book
    {
        private string title;
        private string author;
        private string isbn;
        private string category;
        private BookStatus status;
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public string Category { get; set; }
        public BookStatus Status { get; set; }
       
        public Book(string title, string author, string isbn, string category, BookStatus status=BookStatus.Tillgänglig)
        {
            Title = title;
            Author = author;
            Isbn = isbn;
            Category = category;
            Status = status;
        }
        public override string ToString()
        {        
            return $"{Author.PadRight(20)}\t{Title.PadRight(35)}\t{Isbn.PadRight(15)}\t{Category.PadRight(15)}\t{Status.ToString().PadRight(20)}";
        }
        public static StringBuilder BookReportHeader = new StringBuilder();         
    }
}
