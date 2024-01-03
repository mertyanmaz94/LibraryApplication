using Application.Interfaces;
using Application.ViewModels;
using Domain.Models;
using FluentValidation;

namespace Application.ValidationRules.FluentValidation.QrCode
{
    public class QrCodeValidator : AbstractValidator<QrCodeModel>
    {
        private readonly IGoogleUtilities googleUtilities;
        private readonly ILoginSessionService loginSessionService;

        public QrCodeValidator(IGoogleUtilities googleUtilities, ILoginSessionService loginSessionService)
        {
            this.googleUtilities = googleUtilities;
            this.loginSessionService = loginSessionService;
            AdminUser admin = loginSessionService.GetAdminUser();
            RuleFor(x => new { x.InputCode })
                            .Must(x => this.googleUtilities.ValidateTwoFactorPIN(admin.AccountSecretKey, x.InputCode))
                            .WithMessage("Wrong authenticator code!");
        }
    }
}
