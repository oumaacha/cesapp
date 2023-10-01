using Microsoft.AspNetCore.Mvc;

namespace cesapp.Controllers
{
	public class DashboardController : Controller
	{
		public IActionResult ConsommationDashboard()
		{
			return View();
		}
		public IActionResult RondementDashboard()
		{
			return View();
		}
	}
}
