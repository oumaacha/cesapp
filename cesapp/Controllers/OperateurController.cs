using cesapp.Context;
using cesapp.Models;
using cesapp.Services;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace cesapp.Controllers
{
	public class OperateurController : Controller
	{
		private readonly ApplicationDbContext _context;
        private readonly ISessionsHandler _sessionsHandler;
        public OperateurController(ApplicationDbContext context, ISessionsHandler sessionsHandler)
        {
            _context = context;
            _sessionsHandler = sessionsHandler;
        }
        public IActionResult Index(int? page)
		{
            int pageNumber = page ?? 1;
            int pageSize = 9;
            var operateurs = _context.Operateurs
                .OrderBy(o => o.OperateurName)
                .ToPagedList(pageNumber, pageSize);
            var user = _sessionsHandler.getUserSession("connectedUser");
            ViewData["userRole"] = user.RoleId;
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
        public IActionResult Liberer(int id)
        {
            var machine = _context.Machines.FirstOrDefault(M => M.OperateurId == id);
            var operateur = _context.Operateurs.FirstOrDefault(O => O.OperateurId == id);
			if (machine.Operateur != null)
            {
				machine.OperateurId = null;
                operateur.isAvailable = true;
				_context.SaveChanges();
			}
            return RedirectToAction("Index","Operateur");
        }
        public IActionResult Edit(int id)
        {
            var operateur = _context.Operateurs.FirstOrDefault(O => O.OperateurId == id);
            return View(operateur);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Operateur operateur)
        {
            if (ModelState.IsValid)
            {
                var oldOperateur = _context.Operateurs.FirstOrDefault(o => o.OperateurId == operateur.OperateurId);
                oldOperateur.OperateurName = operateur.OperateurName;
                oldOperateur.OperateurPhone = operateur.OperateurPhone;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
