using System.ComponentModel.DataAnnotations;

namespace PersonalInfo.Core.Models.Enums
{
	public enum FamilyStatus
	{
		[Display(Name = "Холост")]
		Single = 0,
		[Display(Name = "Женат(Замужем)")]
		Maried = 1
	}
}
