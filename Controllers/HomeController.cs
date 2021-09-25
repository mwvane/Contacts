using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
	public class HomeController : Controller
	{
		public RedirectToRouteResult Index()
		{
			var isLoggedIn = Models.User.IsLoggedIn();
			if (isLoggedIn)
			{
				return RedirectToAction("Index", "Contacts");
			} 
			else
			{
				return RedirectToAction("Index", "Auth");
			}

		}
	}
}