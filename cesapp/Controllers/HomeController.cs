using cesapp.Models;
using cesapp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace cesapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISessionsHandler _sessionsHandler;

        public HomeController(ISessionsHandler sessionsHandler)
        {
            _sessionsHandler = sessionsHandler;
        }

        public IActionResult Index()
        {
            if (_sessionsHandler.getUserSession("connectedUser") != null)
            {
                return RedirectToAction("ConsommationDashboard", "Dashboard");
            }
            return RedirectToAction("Login","Account"); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}