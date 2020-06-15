using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
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

			var passport = new Passport()
			{
				Id = Guid.NewGuid(),
				UserId = user.Id
			};

			var education = new Education()
			{
				Id = Guid.NewGuid(),
				UserId = user.Id
			};

			user.Passport = passport;
			user.Education = education;
			user.PassportId = passport.Id;
			user.EducationId = education.Id;

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
			return RedirectToAction("RegisterStep2", user);
		}

		[HttpGet]
		public IActionResult RegisterStep2(User user)
		{
			var passport = new PassportVM()
			{
				UserId = user.Id
			};
			return View(passport);
		}

		[HttpPost]
		public IActionResult RegisterStep2([FromForm]PassportVM userPassport)
		{
			var passport = _db.Passports.FirstOrDefault(p => p.Id == userPassport.UserId) ?? new Passport() { UserId = userPassport.UserId, Id = Guid.NewGuid() };

			passport.Id = Guid.NewGuid();
			passport.BirthPlace = userPassport.BirthPlace;
			passport.BirthDay = userPassport.BirthDay;
			passport.Citizenship = userPassport.Citizenship;
			passport.CountOfChildren = userPassport.CountOfChildren;
			passport.FamilyStatus = userPassport.FamilyStatus;
			passport.Number = userPassport.Number;
			passport.LivePlace = userPassport.LivePlace;
			passport.DateOfIssue = userPassport.DateOfIssue;
			passport.EndOfPassport = userPassport.EndOfPassport;

			passport.PassportCopyImage = SaveFile(userPassport.PassportCopy, "documents");
			passport.MedicalCopy = SaveFile(userPassport.Medical, "documents");
			passport.CriminalRecordImage = SaveFile(userPassport.PrisonCopy, "documents");
			passport.PsychologyCopyImage = SaveFile(userPassport.AlcoCopy, "documents");

			_db.Passports.Add(passport);
			_db.SaveChanges();
			return RedirectToAction("RegisterStep3", _db.Users.FirstOrDefault(p => p.Id == userPassport.UserId));
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

		private static string SaveFile(IFormFile file, string folder)
		{
			if (file == null)
			{
				return null;
			}

			var fileName = $"{Guid.NewGuid()}__{file.FileName}";
			var saveImagePath = $"images/{folder}/{fileName}";
			var fullPath = Path.Combine(Statics.WebRootPath, saveImagePath);

			try
			{
				using (var fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
				{
					file.CopyTo(fileStream);
					return fileName;
				}
			}
			catch
			{
				return null;
			}
		}


	}
}