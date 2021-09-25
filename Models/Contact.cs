using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication10.Models
{
	public class Contact
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		[Required]
		[StringLength(100, MinimumLength =  6)]
		public string Name { get; set; }

		[Required]
		[Phone]
		[MinLength(5)]
		public string PhoneNumber { get; set; }
		public string Avatar { get; set; }
	}
}