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
		public static void InitializeUsers(Context context)
		{
			if (context.Users.Any()) return;
			context.Users.AddRange(new User
			{
				Id = Guid.NewGuid(),
				Email = "admin@gmail.com",
				Name = "Admin",
				Sex = Sex.Man,
				PasswordSalt = "PasswordSalt",
				PasswordHash = Sha256.Hash("PasswordSalt" + "3452"),
				Role = Role.Administrator
			});

			context.SaveChanges();

		}
	}
}