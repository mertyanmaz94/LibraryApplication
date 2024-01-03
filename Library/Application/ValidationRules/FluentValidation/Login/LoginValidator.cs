using Application.Interfaces;
using Application.Utilities;
using Application.ViewModels;
using FluentValidation;

namespace Application.ValidationRules.FluentValidation.Login
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        private readonly IAdminUserService adminUserService;
        public LoginValidator(IAdminUserService adminUserService)
        {
            this.adminUserService = adminUserService;
            RuleFor(x => x.UserName)
            .NotEmpty()
            .WithMessage("Lütfen kullanıcı adınızı giriniz.")
            .DependentRules(() =>
            {
                RuleFor(x => x.Password)
                    .NotEmpty()
                    .WithMessage("Lütfen şifrenizi giriniz.")
                    .DependentRules(() =>
                    {
                        RuleFor(x => new { x.UserName, x.Password })
                            .Must(x => this.adminUserService.IsAdminExist(x.UserName, AppUtilities.EncryptSHA256(x.Password)))
                            .WithMessage("Kullanıcı adı veya şifreniz hatalı!");
                    });
            });
        }
    }
}
