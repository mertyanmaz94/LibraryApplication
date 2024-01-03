using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ReaderRepository(MssqlDbContext context) : IReaderRepository
    {
        private readonly MssqlDbContext context = context;
        public Reader AddReader(Reader reader)
        {
            context.Readers.Add(reader);
            context.SaveChanges();
            return reader;
        }

        public Reader UpdateInventory(Reader reader)
        {
            context.Entry(reader).State = EntityState.Modified;
            context.SaveChanges();
            return reader;
        }

		public Reader GetReader(int ID)
		{
			return context.Readers.Where(x => x.ID == ID).FirstOrDefault();
		}
	}
}
