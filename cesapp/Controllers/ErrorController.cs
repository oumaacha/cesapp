using Microsoft.AspNetCore.Mvc;

namespace cesapp.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
