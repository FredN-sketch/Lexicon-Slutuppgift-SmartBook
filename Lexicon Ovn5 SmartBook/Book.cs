using System.Text;

namespace Lexicon_Slutuppgift_SmartBook
{
    public class Book
    {        
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
            string author = Author.Length <= 20 ? Author : Author.Substring(0, 20);
            string title = Title.Length <= 36 ? Title : Title.Substring(0, 36);
            string isbn = Isbn.Length <= 15 ? Isbn : Isbn.Substring(0, 15);
            string category = Category.Length <= 15 ? Category : Category.Substring(0, 15);
            return $"{author,-20}\t{title.PadRight(36)}\t{isbn.PadRight(15)}\t{category.PadRight(15)}\t{Status.ToString()}";
        }
        //Substring och Padright för att kolumnlängd vid utskrift ska vara densamma oavsett längd på strängarna

        //används vid utskrift av bok/boklista. Initieras i LibraryApp.InitiateBookReportHeader()
        public static StringBuilder BookReportHeader = new StringBuilder();         
    }
}
