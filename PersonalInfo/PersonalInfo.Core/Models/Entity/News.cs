namespace PersonalInfo.Core.Models.Entity
{
	public class News : Base
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public bool IsArhive { get; set; }
	}
}