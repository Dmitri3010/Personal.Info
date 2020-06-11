using System;
using PersonalInfo.Core.Models.Enums;

namespace PersonalInfo.Core.Models.Entity
{
	public class Passport : Base
	{
		public DateTimeOffset BirthDay { get; set; }

		public string Number { get; set; }

		public DateTimeOffset DateOfIssue { get; set; }

		public string BirthPlace { get; set; }

		public string LivePlace { get; set; }

		public string Citizenship { get; set; }

		public FamilyStatus FamilyStatus { get; set; }

		public int CountOfChildren { get; set; }
	}
}