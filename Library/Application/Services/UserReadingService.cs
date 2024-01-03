using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
	public class UserReadingService(IUserReadingRepository userReadingRepository) : IUserReadingService
	{
		private readonly IUserReadingRepository userReadingRepository = userReadingRepository;

		public UserReading SaveUserReading(UserReading userReading)
		{
			if (userReading.ID > 0)
			{
				userReading = userReadingRepository.UpdateUserReading(userReading);
			}
			else
			{
				userReading = userReadingRepository.AddUserReading(userReading);
			}
			return userReading;
		}

		public UserReading GetUserReading(int bookID)
		{
			return userReadingRepository.GetUserReading(bookID);
		}
	}
}
