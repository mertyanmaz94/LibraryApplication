using Domain.Models;

namespace Domain.Interfaces
{
    public interface IBookTypeRepository
    {
        public List<BookType> GetBookTypes();
    }
}
