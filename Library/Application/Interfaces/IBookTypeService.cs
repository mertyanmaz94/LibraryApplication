using Domain.Models;

namespace Application.Interfaces
{
    public interface IBookTypeService
    {
        public List<BookType> GetBookTypes();
    }
}
