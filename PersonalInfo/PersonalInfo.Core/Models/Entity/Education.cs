﻿using System;
using PersonalInfo.Core.Models.Enums;

namespace PersonalInfo.Core.Models.Entity
{
	public class Education : Base
	{
		public EducationType EducationType { get; set; }

		public string Qualification { get; set; }

		public string Specialty { get; set; }

		public DateTimeOffset DateOfGradulation { get; set; }

		public string CopyOfDiploma { get; set; }
	}
}
