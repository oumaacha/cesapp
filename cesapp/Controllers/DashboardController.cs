using Microsoft.AspNetCore.Mvc;

namespace cesapp.Controllers
{
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
