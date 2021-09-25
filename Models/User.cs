using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using WebApplication10.Constants;

namespace WebApplication10.Models
{
	public class User
	{
		public int Id { get; set; }

		[Required]
		[StringLength(30, MinimumLength = 6)]
		public string Username { get; set; }
		[Required]
		[StringLength(30, MinimumLength = 6)]
		public string Password { get; set; }

		public static bool IsLoggedIn()
		{
			var isLogged = HttpContext.Current.Session[
				Constants.Constants.IS_LOGGED_IN
				];

			if (isLogged == null)
			{
				return false;
			}

			return (bool)isLogged; ;
		}

		public static User getCurrentUser()
		{
			var user = HttpContext.Current.Session[Constants.Constants.CURRENT_USER];
			return (User) user;
		}
	}
}