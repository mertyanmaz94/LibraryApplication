using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class UserReadingRepository(MssqlDbContext context) : IUserReadingRepository
	{
		private readonly MssqlDbContext context = context;

		public UserReading AddUserReading(UserReading userReading)
		{
			context.UserReadings.Add(userReading);
			context.SaveChanges();
			return userReading;
		}

		public UserReading UpdateUserReading(UserReading userReading)
		{
			context.Entry(userReading).State = EntityState.Modified;
			context.SaveChanges();
			return userReading;
		}

		public UserReading GetUserReading(int bookID)
		{
			return context.UserReadings.Where(x => x.BookID == bookID).FirstOrDefault();
		}
	}
}
