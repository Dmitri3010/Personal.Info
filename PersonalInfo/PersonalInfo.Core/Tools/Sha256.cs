using System.Security.Cryptography;
using System.Text;

namespace PersonalInfo.Core.Tools
{
	public static class Sha256
	{
		public static string Hash(string value)
		{
			using (SHA256 mySHA256 = SHA256.Create())
			{
				var hashValue = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(value));

				StringBuilder builder = new StringBuilder();
				foreach (var bit in hashValue)
				{
					builder.Append(bit.ToString("x2"));
				}
				return builder.ToString();
			}
		}
	}
}