using Application.ConfigModels;
using Application.Interfaces;
using Application.Logging;
using Application.Services;
using Application.Utilities;
using Application.ValidationRules.FluentValidation.Book;
using Application.ValidationRules.FluentValidation.Login;
using Application.ValidationRules.FluentValidation.QrCode;
using Application.ViewModels;
using Domain.Interfaces;
using FluentValidation;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Ioc
{
    //bağımlılık enjeksiyonu olarak özetleyebileceğimiz DependencyInjection sayesinde nesnelerin ihtiyaç duyduğu bağımlıkları dışarıdan almasını sağlıyoruz.
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration _configuration)
        {
            ConfigModel configModel = _configuration.Get<ConfigModel>();
            services.AddSingleton(configModel);

            services.AddScoped<IAdminUserRepository, AdminUserRepository>();
            services.AddScoped<IAdminUserService, AdminUserService>();
            services.AddScoped<ILoginSessionService, LoginSessionService>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookTypeRepository, BookTypeRepository>();
            services.AddScoped<IBookTypeService, BookTypeService>();
            services.AddScoped<IReaderService, ReaderService>();
            services.AddScoped<IReaderRepository, ReaderRepository>();
            services.AddScoped<IUserReadingRepository, UserReadingRepository>();
            services.AddScoped<IUserReadingService, UserReadingService>();

			services.AddScoped<IValidator<LoginDto>, LoginValidator>();
            services.AddScoped<IValidator<QrCodeModel>, QrCodeValidator>();
            services.AddScoped<IValidator<BookDto>, BookDtoValidator>();

			services.AddScoped<IGoogleUtilities, GoogleUtilities>();
			services.AddScoped<IHttpUtilities, HttpUtilities>();
            services.AddScoped<ILoggerManager, LoggerManager>();

            services.AddDbContext<MssqlDbContext>(options =>
            options.UseSqlServer(configModel.ConnectionStrings.MsSqlConnection), ServiceLifetime.Transient);
        }
    }
}
