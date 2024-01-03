using Domain.Models;

namespace Application.Interfaces
{
	public interface IUserReadingService
	{
		public UserReading SaveUserReading(UserReading userReading);
		public UserReading GetUserReading(int bookID);
	}
}
