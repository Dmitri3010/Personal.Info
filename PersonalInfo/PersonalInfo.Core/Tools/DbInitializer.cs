using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PersonalInfo.Core.Db;
using PersonalInfo.Core.Models.Entity;
using PersonalInfo.Core.Models.Enums;

namespace PersonalInfo.Core.Tools
{
	public class DbInitializer
	{
		private static Context _dbContext;
		public DbInitializer(Context context)
		{
			_dbContext = context;
		}
		public void InitializeUsers()
		{
			if (_dbContext.Users.Any()) return;
			_dbContext.Users.AddRange(new User
			{
				Id = Guid.NewGuid(),
				Email = "admin@gmail.com",
				Name = "Admin",
				Sex = Sex.Man,
				PasswordSalt = "PasswordSalt",
				PasswordHash = Sha256.Hash("PasswordSalt" + "3452"),
				Role = Role.Administrator,
				Education = new Education(),
				Passport = new Passport()
			});

			_dbContext.SaveChanges();
		}

		public void CreateDb(bool drop)
		{
			if (drop)
			{
				try
				{
					_dbContext.Database.EnsureDeleted();
				}
				catch (Exception ex)
				{
					// ignored
				}
			}

			_dbContext.Database.EnsureCreated();
		}
	}
}