using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalInfo.Core.Db;
using PersonalInfo.Core.Models.Entity;

namespace PersonalInfo.Controllers
{
	public class AdminController : Controller
	{
		private readonly Context _db;

		public AdminController(Context context)
		{
			_db = context;
		}

		public IActionResult FAQList()
		{
			return View(_db.Faqs.ToList());
		}

		public IActionResult FAQAddOrUpdate(FAQ faq)
		{
			return View();
		}
	}
}