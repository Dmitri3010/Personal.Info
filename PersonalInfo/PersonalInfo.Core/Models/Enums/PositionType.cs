using System.ComponentModel.DataAnnotations;

namespace PersonalInfo.Core.Models.Enums
{
	public enum PositionType
	{
		[Display(Name = "Маляр")]
		painter = 0,
		[Display(Name = "Разнорабочий")]
		diffworker = 1,
		[Display(Name = "Бригадир")]
		foreman = 2,
		[Display(Name = "Сварщик")]
		welder = 3,
		[Display(Name = "Монтажник")]
		installer = 4,
		[Display(Name = "Электрик")]
		electrician = 5
	}
}