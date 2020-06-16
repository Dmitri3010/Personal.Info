using System.ComponentModel.DataAnnotations;

namespace PersonalInfo.Core.Models.Enums
{
	public enum EducationType
	{
		[Display(Name = "Среднее")]
		Middle = 0,
		[Display(Name = "Высшее")]
		Higner = 1,
		[Display(Name = "Среднее-специальное")]
		MiddleSpecial = 2
	}
}
