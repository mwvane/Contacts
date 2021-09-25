using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class ContactsController : Controller
    {
        protected MyDbContext _context = new MyDbContext();
        // GET: Constacts
        public ActionResult Index()
        {
            if (!Models.User.IsLoggedIn())
			{
                return RedirectToAction("Index", "Auth");
			}

            User user = WebApplication10.Models.User.getCurrentUser();
            int id = user.Id;
            var contacts = _context.Contacts.Where(t => t.UserId == id)
                .ToList();

            return View(contacts);
        }

        public ActionResult AddContact()
		{
            if (!Models.User.IsLoggedIn())
			{
                return RedirectToAction("Index", "Auth");
			}

            return View(new Contact());
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateContact([Bind(Include = "Name, PhoneNumber")] Contact contact)
		{
            if (!ModelState.IsValid)
			{
                return View("AddContact", contact);
            }

            contact.UserId = Models.User.getCurrentUser().Id;

            _context.Contacts.Add(contact);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}