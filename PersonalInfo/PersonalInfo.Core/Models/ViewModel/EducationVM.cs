using System;
using Microsoft.AspNetCore.Http;
using PersonalInfo.Core.Models.Enums;

namespace PersonalInfo.Core.Models.ViewModel
{
	public class EducationVM
	{
		public EducationType EducationType { get; set; }

		public string Qualification { get; set; }

		public string Specialty { get; set; }

		public int DateOfGradulation { get; set; }

		public Guid UserId { get; set; }

		public PositionType PositionType { get; set; }

		public float WorkTime { get; set; }

		public IFormFile DiplomaScan { get; set; }

		public IFormFile WorkBookScan { get; set; }
	}
}
