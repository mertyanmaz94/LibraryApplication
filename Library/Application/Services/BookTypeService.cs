using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class BookTypeService(IBookTypeRepository bookTypeRepository) : IBookTypeService
    {
        private readonly IBookTypeRepository bookTypeRepository = bookTypeRepository;

        public List<BookType> GetBookTypes()
        {
            return bookTypeRepository.GetBookTypes();
        }
    }
}
