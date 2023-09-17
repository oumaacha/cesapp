using cesapp.Context;
using cesapp.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace cesapp.Controllers
{
	public class ResponsableController : Controller
	{
        private readonly ApplicationDbContext _context;
        public ResponsableController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? page)
		{
            int pageNumber = page ?? 1;
            int pageSize = 9;
            var responsables = _context.Responsables
                .ToPagedList(pageNumber, pageSize);
            return View(responsables);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Responsable responsable)
        {
            if (ModelState.IsValid){
                if(responsable != null)
                {
                    _context.Responsables.Add(responsable);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index","Responsable");
        }
    }
}
