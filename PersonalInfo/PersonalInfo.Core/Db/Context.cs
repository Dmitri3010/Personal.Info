using Microsoft.EntityFrameworkCore;
using PersonalInfo.Core.Models.Entity;

namespace PersonalInfo.Core.Db
{
	public sealed class Context : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Position> Positions { get; set; }
		public DbSet<Passport> Passports { get; set; }
		public DbSet<Education> Educations { get; set; }
		public DbSet<DriverLicense> DriverLicenses { get; set; }
		public DbSet<LogginedUser> LoginedUsers { get; set; }
		public DbSet<FAQ> Faqs { get; set; }
		public DbSet<News> News { get; set; }

		public Context(DbContextOptions<Context> contextOptions) 
			: base(contextOptions)
		{
			Database.EnsureCreated();
		}

	}
}