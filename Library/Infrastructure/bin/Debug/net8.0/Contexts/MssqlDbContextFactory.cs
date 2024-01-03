using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;


namespace Infrastructure.Contexts
{
	public class MssqlDbContextFactory : IDesignTimeDbContextFactory<MssqlDbContext>
	{
		public IConfiguration configuration;
		public MssqlDbContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<MssqlDbContext>();
			var folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile(Path.Combine(folderPath, "sharedsettings.json"), false, true)
				.AddEnvironmentVariables()
				.Build();
			optionsBuilder.UseSqlServer(GetDbConnectionString());
			return new MssqlDbContext(optionsBuilder.Options);
		}
		private string GetDbConnectionString()
		{
			return configuration.GetSection("ConnectionStrings:MsSqlConnection").Value;
		}
	}
}
