using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalInfo.Core.Db;
using PersonalInfo.Core.Models.Entity;
using PersonalInfo.Core.Models.ViewModel;
using PersonalInfo.Core.Tools;

namespace PersonalInfo.Controllers
{
	public class AuthController : Controller
	{
		private readonly Context db;

		public AuthController(Context context)
		{
			db = context;
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Login(Auth user)
		{
			if (!Validate.Validator(user))
			{
				return RedirectToAction("Login");
			}

			var userFromDb = db.Users.FirstOrDefault(p => p.Email == user.Email);
			if (userFromDb == null)
			{
				return RedirectToAction("Login");
			}

			return Sha256.Hash(user.Password + userFromDb.PasswordSalt) 
					!= userFromDb.PasswordHash ? RedirectToAction("Login") 
					: RedirectToAction("", "");
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}
	}
}