using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PersonalInfo.Core.Tools
{
	public static class Validate
	{
		public static bool Validator<T>(T x)
		{
			return x != null;
		}
	}
}
