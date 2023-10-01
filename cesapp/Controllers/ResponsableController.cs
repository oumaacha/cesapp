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
                .OrderBy(r => r.ResponsableLName)
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

        public IActionResult Edit(int id)
        {
            var responsable = _context.Responsables.FirstOrDefault(R => R.ResponsableId == id);
            return View(responsable);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Responsable responsable)
        {
            if (ModelState.IsValid)
            {
                var oldResponsable = _context.Responsables.FirstOrDefault(R => R.ResponsableId == responsable.ResponsableId);
                oldResponsable.ResponsableFName = responsable.ResponsableFName;
                oldResponsable.ResponsableLName = responsable.ResponsableLName;
                oldResponsable.CodeTelephone = responsable.CodeTelephone;
                oldResponsable.NumeroTelephone = responsable.NumeroTelephone;
                oldResponsable.Mail = responsable.Mail;
                oldResponsable.Matricule = responsable.Matricule;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
