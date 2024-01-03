using Domain.Models;

namespace Application.Interfaces
{
    public interface IBookService
    {
        public List<Book> GetBooks();
        public List<Book> GetBooks(int bookTypeID);
        public Book GetBook(int ID);
        public Book SaveBook(Book book);
    }
}
