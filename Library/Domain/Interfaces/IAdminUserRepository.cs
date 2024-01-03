using Domain.Models;

namespace Domain.Interfaces
{
	//repository'lerimize ulaşmak için kullandığımız interfacelerimiz
	public interface IAdminUserRepository
	{
		AdminUser AddAdmin(AdminUser admin);
		AdminUser GetAdmin(string email, string password);
		AdminUser GetAdmin(int ID);
		AdminUser UpdateAdmin(AdminUser admin);
		bool IsAdminUserExist(int ID, string email);
	}
}
