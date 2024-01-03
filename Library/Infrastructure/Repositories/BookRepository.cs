using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BookRepository(MssqlDbContext context) : IBookRepository
    {
        private readonly MssqlDbContext context = context;

        public List<Book> GetBooks()
        {
            return context
                .Books
                .Where(x => x.Status == 1)
                .OrderBy(x => x.Name) 
                .ToList();
        }

        public List<Book> GetBooks(int bookTypeID) 
        {
            return context
               .Books
               .Where(x => x.Status == 1 && x.BookTypeID == bookTypeID)
               .OrderBy(x => x.Name)
               .ToList();
        }

        public Book GetBook(int ID)
        {
            return context.Books.Where(x => x.ID == ID).FirstOrDefault();
        }

        public Book AddBook(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
            return book;
        }

        public Book UpdateBook(Book book)
        {
            context.Entry(book).State = EntityState.Modified; 
            context.SaveChanges();
            return book;
        }
    }
}
