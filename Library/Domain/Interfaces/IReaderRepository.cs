using Domain.Models;

namespace Domain.Interfaces
{
    public interface IReaderRepository
    {
        public Reader AddReader(Reader reader);
        public Reader UpdateInventory(Reader reader);
        public Reader GetReader(int ID);

	}
}
