using Domain.Models;

namespace Application.Interfaces
{
	public interface IAdminUserService
	{
		AdminUser GetAdmin(string email, string password);
		AdminUser GetAdmin(int ID);
		AdminUser SaveAdmin(AdminUser adminUserDto);
		bool IsAdminExist(string email, string password);
		bool IsAdminUserExist(int ID, string email);
	}
}
