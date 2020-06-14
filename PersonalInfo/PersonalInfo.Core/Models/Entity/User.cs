using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using Newtonsoft.Json;
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

		public string Social { get; set; }

		[NotMapped]
		public Dictionary<SocialLinks, string> SocialLinks
		{
			get => JsonConvert.DeserializeObject<Dictionary<SocialLinks, string>>(Social);
			set => Social = JsonConvert.SerializeObject(value);
		}

		public string Image { get; set; }

		public Passport Passport { get; set; }

		public Guid PassportId { get; set; }

		public Education Education { get; set; }

		public Guid EducationId { get; set; }
	}
}