using System.Collections.Generic;
using PersonalInfo.Core.Models.Enums;

namespace PersonalInfo.Core.Models.Entity
{
	public class User : Base
	{
		public string Name { get; set; }

		public string Surname { get; set; }

		public string SecondName { get; set; }

		public Sex Sex { get; set; }

		public string Email { get; set; }

		public string Phone { get; set; }

		public string PasswordHash { get; set; }

		public string PasswordSalt { get; set; }

		public Role Role { get; set; }

		public Dictionary<SocialLinks, string> SocialLinks { get; set; }

		public string Image { get; set; }
	}
}