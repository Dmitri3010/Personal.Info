using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalInfo.Core.Models.Entity
{
	public class LogginedUser : Base
	{
		public Guid UserId { get; set; }

		public Guid AuthToken { get; set; }

		public DateTimeOffset LoginTime { get; set; }

		public int TimeoutMins { get; set; }
	}
}
