using Application.Interfaces;
using Application.ValidationRules.FluentValidation.Login;
using Application.ViewModels;
using Domain.Models;
using FluentValidation;
using Google.Authenticator;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Web.Controllers
{
	public class LoginController(IAdminUserService adminUserService, IGoogleUtilities googleUtilities, ILoginSessionService loginSessionService, IValidator<LoginDto> loginValidator) : Controller
	{
		private readonly IAdminUserService adminUserService = adminUserService;
		private readonly IGoogleUtilities googleUtilities = googleUtilities;
		private readonly ILoginSessionService loginSessionService = loginSessionService;
        private readonly IValidator<LoginDto> loginValidator = loginValidator;
        public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(LoginDto loginDto)
		{
			if (loginValidator.Validate(loginDto).IsValid)

            {
				return RedirectToAction("QRCode", "Login");
			}
			return View();
		}

		public IActionResult QRCode()
		{
			AdminUser adminUser = null;
			SetupCode setup = null;
			QrCodeModel qrCode = new QrCodeModel();
			adminUser = loginSessionService.GetAdminUser();
			qrCode.SetupCodeVisibility = "none";
			qrCode.AdminUserID = adminUser.ID;
			if (String.IsNullOrWhiteSpace(adminUser.AccountSecretKey))
			{
				adminUser.AccountSecretKey = Guid.NewGuid().ToString();
				loginSessionService.SetAdminUser(adminUser);
				adminUserService.SaveAdmin(adminUser);
			}
			if (!adminUser.AuthenticatorFlag)
			{
				setup = googleUtilities.GenerateTwoFactorAuthentication(adminUser.ID, adminUser.AccountSecretKey);
				qrCode.SetupCodeVisibility = "block";
				qrCode.SetupCode = setup.ManualEntryKey;
				qrCode.BarcodeImageUrl = setup.QrCodeSetupImageUrl;
			}
			return View(qrCode);
		}

		[HttpPost]
		public IActionResult QRCode(QrCodeModel qrCode)
		{
			AdminUser admin = null;
			admin = loginSessionService.GetAdminUser();
			if (ModelState.IsValid)
			{
				if (!admin.AuthenticatorFlag)
				{
					admin.AuthenticatorFlag = true;
					adminUserService.SaveAdmin(admin);
				}

				loginSessionService.ClearSession();
				HttpContext.Session.SetString("User", JsonSerializer.Serialize(admin));
				return RedirectToAction("List", "Book");
			}
			return View(qrCode);
		}

		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("Index", "Login");
		}
	}
}
