using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonalInfo.Auth;
using PersonalInfo.Core.Db;
using PersonalInfo.Core.Models.Entity;
using PersonalInfo.Core.Models.ViewModel;
using PersonalInfo.Core.Tools;

namespace PersonalInfo.Controllers
{
	public class AuthController : Controller
	{
		private readonly Context _db;

		public AuthController(Context context)
		{
			_db = context;
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Login(Core.Models.ViewModel.Auth user)
		{
			if (!Validate.Validator(user))
			{
				return RedirectToAction("Login");
			}

			var userFromDb = _db.Users.FirstOrDefault(p => p.Email == user.Email);
			if (userFromDb == null)
			{
				return RedirectToAction("Login");
			}

			if (Sha256.Hash(user.Password + userFromDb.PasswordSalt) != userFromDb.PasswordHash)
				return RedirectToAction("Login");

			var logginedUser = new LogginedUser()
			{
				Id = Guid.NewGuid(),
				UserId = userFromDb.Id,
				AuthToken = Guid.NewGuid(),
				TimeoutMins = 180,
				LoginTime = DateTimeOffset.Now
			};

			_db.LoginedUsers.Add(logginedUser);
			_db.SaveChanges();

			Response.Cookies.Append("AuthToken", logginedUser.AuthToken.ToString());

			return RedirectToAction("Index", "Main");
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Register(User authUser)
		{
			if (!Validate.Validator(authUser))
			{
				return RedirectToAction("Login");
			}

			var user = Mapper.Map<User>(authUser);

			_db.Users.Add(user);
			_db.SaveChanges();
			return RedirectToAction("", "");
		}
	}
}