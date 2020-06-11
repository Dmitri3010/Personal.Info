using PersonalInfo.Core.Models.Enums;

namespace PersonalInfo.Core.Models.Entity
{
	public class Position : Base
	{
		public PositionType PositionType { get; set; }

		public float ExperienceDate { get; set; }

		public string CopyOfWorkBook { get; set; }
	}
}