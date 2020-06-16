using System;
using Microsoft.AspNetCore.Http;
using PersonalInfo.Core.Models.Enums;

namespace PersonalInfo.Core.Models.ViewModel
{
	public class DriverLicenseVm
	{
		public string Range { get; set; }

		public string Number { get; set; }

		public DateTimeOffset DueDate { get; set; }

		public Category Category { get; set; }

		public bool IsExist { get; set; }

		public IFormFile CopyOfLicense { get; set; }

		public Guid UserId { get; set; }

	}
}