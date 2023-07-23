using cesapp.Context;
using cesapp.Models;
using cesapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace cesapp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ISessionsHandler _sessionsHandler;
        public AccountController(ApplicationDbContext context, ISessionsHandler sessionsHandler)
        {
            _context = context;
            _sessionsHandler = sessionsHandler;
		}
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserLogin userLogin) {
            if (ModelState.IsValid)
            {
                var userFromDb = _context.Users.FirstOrDefault(u => u.Email == userLogin.Email);
                if (userFromDb != null && _context.Users.FirstOrDefault(u => u.PasswordHash == userLogin.PasswordHash) != null)
                {
                    userFromDb.LastConnection = DateTime.UtcNow;
                    _context.SaveChanges();
                    _sessionsHandler.setUserSession("connectedUser",userFromDb);
					return RedirectToAction("Index","Home");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            _sessionsHandler.clearSession();
            return RedirectToAction("Login", "Account");
        }
    }
}
