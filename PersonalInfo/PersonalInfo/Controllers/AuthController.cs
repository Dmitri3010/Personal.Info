using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PersonalInfo.Core.Db;
using PersonalInfo.Core.Models.Entity;
using PersonalInfo.Core.Models.Enums;
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
		public IActionResult Register(Register authUser)
		{
			if (!Validate.Validator(authUser))
			{
				return RedirectToAction("Login");
			}

			var user = new User()
			{
				Id = Guid.NewGuid(),
				Name = authUser.Name,
				SecondName = authUser.SecondName,
				Surname = authUser.Surname,
				Sex = authUser.Sex,
				Email = authUser.Email,
				Phone = authUser.Phone,
				Role = Role.UsualUser,
				Education = new Education(),
				Passport = new Passport(),
				Social = string.Empty,
				SocialLinks = new Dictionary<SocialLinks, string>()
			};

			var passwordSalt = Guid.NewGuid().ToString();
			var passwordHash = Sha256.Hash(authUser.Password + passwordSalt);
			user.PasswordSalt = passwordSalt;
			user.PasswordHash = passwordHash;

			_db.Users.Add(user);
			_db.SaveChanges();
			return RedirectToAction("RegisterStep", user);
		}

		[HttpGet]
		public IActionResult RegisterStep(User user)
		{
			return View(user);
		}

		[HttpPost]
		public IActionResult RegisterStep(Guid userId)
		{
			var user = _db.Users.FirstOrDefault(p => p.Id.ToString() == userId.ToString());
			return RedirectToAction("RegisterStep2",user);
		}

		[HttpGet]
		public IActionResult RegisterStep2(User user)
		{
			return View(user);
		}

		[HttpGet]
		public IActionResult RegisterStep3(User user)
		{
			return View(user);
		}

		[HttpGet]
		public IActionResult RegisterStep4(User user)
		{
			return View(user);
		}
	}
}