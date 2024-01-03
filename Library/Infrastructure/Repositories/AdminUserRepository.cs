using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	//Repository katmanında database ile iletişim kurar, veritabanı işlemlerini gerçekleştiririz.
	public class AdminUserRepository(MssqlDbContext context) : IAdminUserRepository
	{
		private readonly MssqlDbContext context = context;

		public AdminUser AddAdmin(AdminUser admin)
		{
			context.AdminUsers.Add(admin);
			context.SaveChanges();
			return admin;
		}

		public AdminUser GetAdmin(string email, string password)
		{
			return context.AdminUsers.FirstOrDefault(x => x.Email == email && x.Password == password && x.Status == 1);
		}

		public AdminUser GetAdmin(int ID)
		{
			return context.AdminUsers.FirstOrDefault(x => x.ID == ID);
		}

		public bool IsAdminUserExist(int ID, string email)
		{
			return context.AdminUsers.Any(x => x.ID != ID && x.Email == email);
		}

		public AdminUser UpdateAdmin(AdminUser admin)
		{
			context.Entry(admin).State = EntityState.Modified;
			context.SaveChanges();
			return admin;
		}
	}
}
