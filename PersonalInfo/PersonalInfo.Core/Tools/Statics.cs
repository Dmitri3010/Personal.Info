using Microsoft.Extensions.Configuration;

namespace PersonalInfo.Core.Tools
{
	public static class Statics
	{
		public static IConfiguration Configuration { get; set; }

		public static string WebRootPath { get; set; }
	}
}