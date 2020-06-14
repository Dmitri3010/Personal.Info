using System.Linq;
using Microsoft.EntityFrameworkCore;
using PersonalInfo.Core.Models.Entity;

namespace PersonalInfo.Core.Db
{
	public static class GetData
	{
		public static LogginedUser GetLoginedUserByToken(string token)
		{
			using (var context = new Context(new DbContextOptions<Context>()))
			{
				return context.LogginedUsers.FirstOrDefault(p => p.AuthToken.ToString() == token);
			}
		}
	}
}
