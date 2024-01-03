using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories
{
    public class BookTypeRepository(MssqlDbContext context) : IBookTypeRepository
    {
        private readonly MssqlDbContext context = context;

        public List<BookType> GetBookTypes()
        {
            return context.BookTypes.Where(x => x.Status == 1).ToList();
        }
    }
}
