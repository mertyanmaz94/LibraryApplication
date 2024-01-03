using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
	//servislerimizden interfaceler aracılığıyla database işlemlerinin gerçekleştiği repository'lere ulaşırız.
	//fonksiyonlarımızın her biri bir iş yapmalı ve tanımı ne ise işlevi de o olmalıdır.
	public class AdminUserService(IAdminUserRepository adminUserRepository, ILoginSessionService loginSessionService) : IAdminUserService
	{
		private readonly IAdminUserRepository adminUserRepository = adminUserRepository;
		private readonly ILoginSessionService loginSessionService = loginSessionService;

		public AdminUser GetAdmin(string email, string password)
		{
			return adminUserRepository.GetAdmin(email, password);
		}

		public AdminUser GetAdmin(int ID)
		{
			return adminUserRepository.GetAdmin(ID);
		}

		public bool IsAdminExist(string email, string password)
		{
			AdminUser adminUser = adminUserRepository.GetAdmin(email, password);
			if (adminUser == null)
			{
				return false;
			}
			else
			{
				loginSessionService.SetAdminUser(adminUser);
				return true;
			}
		}

		public bool IsAdminUserExist(int ID, string email)
		{
			return adminUserRepository.IsAdminUserExist(ID, email);
		}

		public AdminUser SaveAdmin(AdminUser admin)
		{
			if (admin.ID > 0)
			{
				admin = adminUserRepository.UpdateAdmin(admin);
			}
			else
			{
				admin = adminUserRepository.AddAdmin(admin);
			}
			return admin;
		}
	}
}
