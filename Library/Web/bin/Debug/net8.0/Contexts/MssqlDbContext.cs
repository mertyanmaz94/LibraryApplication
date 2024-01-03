using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    //DbContext sınıfımız aracılığı ile migrationları oluşturup database ile iletişim kurarız.
	public class MssqlDbContext(DbContextOptions<MssqlDbContext> options) : DbContext(options)
	{
		public DbSet<Book> Books { get; set; }
        public DbSet<BookType> BookTypes { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<UserReading> UserReadings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().Property(b => b.InsertionDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Book>().Property(b => b.UpdateDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Book>().Property(b => b.Status).HasDefaultValue(1);
            modelBuilder.Entity<Book>().Property(b => b.InTheLibrary).HasDefaultValue(true);

            modelBuilder.Entity<BookType>().Property(b => b.InsertionDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<BookType>().Property(b => b.UpdateDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<BookType>().Property(b => b.Status).HasDefaultValue(1);

            modelBuilder.Entity<Reader>().Property(b => b.InsertionDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Reader>().Property(b => b.UpdateDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Reader>().Property(b => b.Status).HasDefaultValue(1);

            modelBuilder.Entity<UserReading>().Property(b => b.InsertionDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<UserReading>().Property(b => b.UpdateDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<UserReading>().Property(b => b.Status).HasDefaultValue(1);
        }
    }
}
