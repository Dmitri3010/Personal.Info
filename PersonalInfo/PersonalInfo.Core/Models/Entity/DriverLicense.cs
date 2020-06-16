using System;
using PersonalInfo.Core.Models.Enums;

namespace PersonalInfo.Core.Models.Entity
{
	public class DriverLicense : BaseDocument
	{
		public string Range { get; set; }

		public string Number { get; set; }

		public DateTimeOffset DueDate { get; set; }

		public Category Category { get; set; }

		public bool IsExist { get; set; }

		public string CopyOfLicense { get; set; }

		public Guid UserId { get; set; }
	}
}