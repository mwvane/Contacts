using System.Linq;
using System.Web.Mvc;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class AuthController : Controller
    {
        protected MyDbContext _context = new MyDbContext();

        // GET: Auth
        public ActionResult Index()
        {
            return View(new User());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "username, password")] User user)
        {
            if (!ModelState.IsValid)
			{
                return View("index", user);
            }

            var model = _context.Users
                .Where(u => u.Username == user.Username && 
                       u.Password == user.Password)
                .FirstOrDefault();

            if (model == null)
			{
                ModelState.AddModelError("Username", "Such user does not exist");
                return View("index", user);
			}

            saveUser(model);

            return RedirectToAction("Index", "Contacts");
        }

        public ActionResult Registration()
        {
            return View(new User());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterUser([Bind(Include = "username, password")] User user, [Microsoft.AspNetCore.Mvc.FromForm] string confirmPassword)
        {
			if (!ModelState.IsValid)
			{
                return View("Registration", user);
            }

            if (user.Password != confirmPassword)
			{
                ModelState.AddModelError("Password", "confirm password does not match with this password");
                return View("Registration", user);
			}

            var exists = _context.Users
                .Where(u => u.Username == user.Username)
                .Count() > 0;

            if (exists)
			{
                ModelState.AddModelError("Username", "Such user already exists");
                return View("Registration", user);
			}

            User createdUser = _context.Users.Add(user);
            _context.SaveChanges();
            var d = 1;

            saveUser(createdUser);

            return RedirectToAction("Index", "Contacts");
        }

        private void saveUser(User user)
		{
            Session[Constants.Constants.IS_LOGGED_IN] = true;
			Session[Constants.Constants.CURRENT_USER] = user;
		}
	}
}