using cesapp.Context;
using cesapp.Models;
using DocumentFormat.OpenXml.Office.CustomUI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace cesapp.Controllers
{
    public class RondementController : Controller
    {
		private readonly ApplicationDbContext _context;
		public RondementController(ApplicationDbContext context)
		{
			_context = context;
		}
		public IActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 2;
            var rondements = _context.Rondements
                .Include(R => R.Machine)
                .Include(R => R.Operateur)
                .ToPagedList(pageNumber, pageSize);
            return View(rondements);
        }
        public IActionResult Create(int id)
        {
            var machine = _context.Machines
                .Include(M => M.Operateur)
                .FirstOrDefault(M => M.MachineId== id);
            ViewData["machine"] = machine;
			return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
		public IActionResult Create(Rondement rondement)
		{
            if(ModelState.IsValid)
            {
                if(rondement != null)
                {
                    _context.Rondements.Add(rondement);
                    _context.SaveChanges();
                }
            }
			return RedirectToAction("Index","Rondement");
		}

		/*public IDictionary<string, decimal> MachineRondementDataByIdBars(int id)
		{
			var data = _context.Rondements
				.Where(r => r.MachineId == id)
				.GroupBy(r => r.Date.Month)
				.ToDictionary(
					group => group.Key,
					group => group.Sum()
				);
			return data;

		}*/
		public IDictionary<int, decimal> MachineRondementDataByIdBars(int id)
		{
			int year = int.Parse(HttpContext.Request.Query["year"]);
			var data = _context.Rondements
				.Where(r => r.MachineId == id && r.Date.Year == year)
				.GroupBy(r => r.Date.Month)
				.Select(group => new
				{
					Date = group.Key,
					TotalSCSD = group.Sum(r => r.SC_En_Metre + r.SD_En_Metre), // Sum of SC and SD for the group
					Essai = group.Sum(r => r.EssaiPressiometrique), // Sum of Essai for the group
					SPT = group.Sum(r => r.SPT) // Sum of SPT for the group
				})
				.ToDictionary(
					item => item.Date,
					item => item.TotalSCSD
                );

			return data;
		}
		public IEnumerable<int> GetRondementYears()
		{
			IEnumerable<int> years = _context.Rondements
				.Select(x => x.Date.Year)
				.Distinct();
			return years;
		}
	}
}
