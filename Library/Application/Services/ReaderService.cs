using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class ReaderService(IReaderRepository readerRepository) : IReaderService
    {
        private readonly IReaderRepository readerRepository = readerRepository;

        public Reader SaveReader(Reader reader)
        {
            if(reader.ID > 0)
            {
                readerRepository.UpdateInventory(reader);
            }
            else
            {
                readerRepository.AddReader(reader);
            }
            return reader;
        }

	    public Reader GetReader(int id)
        {
            return readerRepository.GetReader(id);
        }
        
	}
}
