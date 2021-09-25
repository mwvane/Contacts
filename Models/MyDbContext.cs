using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication10.Models
{
	public class MyDbContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Contact> Contacts{ get; set; }

	}
}