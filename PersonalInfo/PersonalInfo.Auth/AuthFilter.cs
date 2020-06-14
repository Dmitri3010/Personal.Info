using System;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.AspNetCore.Mvc.Filters;
using PersonalInfo.Core.Db;
using Remotion.Linq.Parsing.ExpressionVisitors.Transformation.PredefinedTransformations;

namespace PersonalInfo.Auth
{
	public class AuthFilter : Attribute, IAuthorizationFilter
	{
		public void OnAuthorization(AuthorizationFilterContext context)
		{
			context.HttpContext.Request.Cookies.TryGetValue("AuthToken", out var auth_token);
			var user = GetData.GetLoginedUserByToken(auth_token);
		}
	}
}