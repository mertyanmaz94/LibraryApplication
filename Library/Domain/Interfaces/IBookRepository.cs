using Domain.Models;

namespace Domain.Interfaces
{
    public interface IBookRepository
    {
        public List<Book> GetBooks();
        public List<Book> GetBooks(int bookTypeID);
        public Book GetBook(int ID);
        public Book AddBook(Book book);
        public Book UpdateBook(Book book);
    }
}
