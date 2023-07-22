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
	}
}
