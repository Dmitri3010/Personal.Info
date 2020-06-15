using System;
using PersonalInfo.Core.Models.Enums;

namespace PersonalInfo.Core.Models.Entity
{
	public class Passport : BaseDocument
	{
		public DateTimeOffset BirthDay { get; set; }

		public string Number { get; set; }

		public DateTimeOffset DateOfIssue { get; set; }

		public DateTimeOffset EndOfPassport { get; set; }

		public string BirthPlace { get; set; }

		public string LivePlace { get; set; }

		public string Citizenship { get; set; }

		public FamilyStatus FamilyStatus { get; set; }

		public int CountOfChildren { get; set; }

		public string PassportCopyImage { get; set; }

		public string MedicalCopy { get; set; }

		public string CriminalRecordImage { get; set; }

		public string PsychologyCopyImage { get; set; }

		public Guid UserId { get; set; }

	}
}