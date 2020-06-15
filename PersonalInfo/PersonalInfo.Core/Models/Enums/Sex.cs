﻿using System.ComponentModel.DataAnnotations;

namespace PersonalInfo.Core.Models.Enums
{
	public enum Sex
	{
		[Display(Name = "М")]
		Man = 0,
		[Display(Name = "Ж")]
		Women = 1
	}
}