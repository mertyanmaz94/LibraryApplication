using Domain.Models;

namespace Application.Interfaces
{
	public interface ILoginSessionService
	{
		void SetAdminUser(AdminUser adminUser);
		AdminUser GetAdminUser();
		void ClearSession();
	}
}
