using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json;

namespace Application.Services
{
	public class LoginSessionService(IHttpContextAccessor httpContextAccessor) : ILoginSessionService
	{
		private readonly IHttpContextAccessor httpContextAccessor = httpContextAccessor;

		public void SetAdminUser(AdminUser adminUser)
		{
			httpContextAccessor.HttpContext.Session.SetString("LoginStep", JsonSerializer.Serialize(adminUser));
		}

		public AdminUser GetAdminUser()
		{
			var json = httpContextAccessor.HttpContext.Session.GetString("LoginStep");
			return json == null ? null : JsonSerializer.Deserialize<AdminUser>(json);
		}

		public void ClearSession()
		{
			httpContextAccessor.HttpContext.Session.Clear();
		}
	}
}
