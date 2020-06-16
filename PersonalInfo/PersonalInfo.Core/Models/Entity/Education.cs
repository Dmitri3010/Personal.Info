using System;
using PersonalInfo.Core.Models.Enums;

namespace PersonalInfo.Core.Models.Entity
{
	public class Education : BaseDocument
	{
		public EducationType EducationType { get; set; }

		public string Qualification { get; set; }

		public string Specialty { get; set; }

		public int DateOfGradulation { get; set; }

		public string CopyOfDiploma { get; set; }

		public string CopyOfWorkBook { get; set; }

		public Guid UserId { get; set; }

		public PositionType PositionType { get; set; }

		public float WorkTime { get; set; }
	}
}