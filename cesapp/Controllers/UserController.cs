using cesapp.Context;
using cesapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cesapp.Controllers
{
	public class UserController : Controller
	{
		public readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
		{
			IEnumerable<User> users = _context.Users.Include(r => r.Role);
			return View(users);
		}
		public IActionResult Create() {
			IEnumerable<Role> roles = _context.Roles;
			ViewData["roles"] = roles;
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(User user)
		{
			if(ModelState.IsValid)
			{
				_context.Users.Add(user);
				_context.SaveChanges();
				return RedirectToAction("Index","User");
			}
			return Create();
		}

		public IActionResult Delete(int id)
		{
			var user = _context.Users.SingleOrDefault(u => u.UserId == id);
			if(user == null)
			{
				return Content("User not found");
			}
			_context.Users.Remove(user);
			_context.SaveChanges();
			return RedirectToAction("Index", "User");
		}
	}
}
