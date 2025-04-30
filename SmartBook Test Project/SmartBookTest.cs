using Lexicon_Slutuppgift_SmartBook;

namespace SmartBook_Test_Project
{
    public class SmartBookTest
    {
        [Fact]
        public void AddBook_ShouldAddBookToList()
        {
            var lib = new Library();
            var book = new Book("Test", "Test Författare", "123", "Roman");
            lib.AddBook(book);            
            Assert.Contains(book, lib.GetBooks());
        }
        [Fact]
        public void AddAndRemoveBook_ShouldAddAndRemoveBookToList()
        {
            var lib = new Library();
            var book = new Book("Test", "Test Författare", "123", "Roman");
            lib.AddBook(book);
            Assert.Contains(book, lib.GetBooks());
            lib.RemoveBook(book);
            Assert.DoesNotContain(book, lib.GetBooks());
        }
        [Fact]
        public void AddBookAndTestQueries()
        {
            var lib = new Library();
            var book = new Book("Test", "Test Författare", "123", "Roman");
            lib.AddBook(book);
            Assert.Contains(book, lib.QueryTitle("Test"));
            Assert.Contains(book, lib.QueryAuthor("Test Författare"));
            Assert.Equal(book, lib.QueryIsbn("123"));
        }
    }
}
