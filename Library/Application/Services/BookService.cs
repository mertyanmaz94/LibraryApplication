using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class BookService(IBookRepository bookRepository) : IBookService
    {
        private readonly IBookRepository bookRepository = bookRepository;     

        public List<Book> GetBooks()
        {
            return bookRepository.GetBooks();
        }

        public List<Book> GetBooks(int bookTypeID)
        { 
            return bookRepository.GetBooks(bookTypeID); 
        }

        public Book GetBook(int ID)
        {
            return bookRepository.GetBook(ID);
        }

        public Book SaveBook(Book book)
        {
            if (book.ID > 0)
            {
                bookRepository.UpdateBook(book);
            }
            else
            {
                bookRepository.AddBook(book);
            }
            return book;
        }    		
	}
}
