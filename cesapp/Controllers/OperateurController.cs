using cesapp.Context;
using cesapp.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace cesapp.Controllers
{
	public class OperateurController : Controller
	{
		private readonly ApplicationDbContext _context;
        public OperateurController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? page)
		{
            int pageNumber = page ?? 1;
            int pageSize = 9;
            var operateurs = _context.Operateurs
                .ToPagedList(pageNumber, pageSize);
            return View(operateurs);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Operateur operateur)
        {
            if (ModelState.IsValid)
            {
                if(operateur != null)
                {
                    _context.Operateurs.Add(operateur);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index","Operateur");
        }
        public IActionResult Delete(int id)
        {
            var operateur = _context.Operateurs.Find(id);
            if(operateur != null)
            {
                _context.Operateurs.Remove(operateur);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Operateur");
        }
	}
}
