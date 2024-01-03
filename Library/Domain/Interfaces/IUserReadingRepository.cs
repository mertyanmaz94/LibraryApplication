using Domain.Models;

namespace Domain.Interfaces
{
	public interface IUserReadingRepository
	{
		public UserReading AddUserReading(UserReading userReading);
		public UserReading UpdateUserReading(UserReading userReading);
		public UserReading GetUserReading(int bookID);
	}
}
