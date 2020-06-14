namespace PersonalInfo.Core.Tools
{
	public static class Validate
	{
		public static bool Validator<T>(T value)
		{
			return value != null;
		}
	}
}
