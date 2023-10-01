using cesapp.Context;
using cesapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cesapp.Controllers
{
	public class DossierController : Controller
	{
		private readonly ApplicationDbContext _context;
        public DossierController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
		{
			IEnumerable<Dossier> dossiers = _context.Dossiers
				.Include(d => d.Client)
				.Include(d => d.Responsable)
				.Include(d => d.Chantiers);
			return View(dossiers);
		}
		public IActionResult DossierById(int id) {
			var dossier = _context.Dossiers
				.Include(d => d.Client)
				.Include(d => d.Responsable)
				.Include(d => d.Chantiers)
				.FirstOrDefault(d => d.DossierId == id);
			return View(dossier);
		}
		public IActionResult Create()
		{
			IEnumerable<Responsable> responsables = _context.Responsables;
			IEnumerable<Client> clients = _context.Clients;
			ViewData["responsables"] = responsables;
			ViewData["clients"] = clients;
            return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Dossier dossier)
		{
			if (ModelState.IsValid)
			{
				if (dossier!=null) {
					_context.Dossiers.Add(dossier);
					_context.SaveChanges();
				}
			}
			return RedirectToAction("Index","Dossier");
		}

		[Route("/Dossier/GetDossierNum/{data?}")]
		public int GetDossierNum(string data) {
			var dossierid = _context.Dossiers.FirstOrDefault(d => d.DossierNum == data);
			if (dossierid != null) return dossierid.DossierId;
            return 0;
		}

		public IActionResult Edit(int id)
		{
			var dossier = _context.Dossiers
				.Include(d => d.Responsable)
				.Include(d => d.Client)
				.FirstOrDefault(d => d.DossierId == id);
			var clients = _context.Clients;
			var responsables = _context.Responsables;
			ViewData["clients"] = clients;
			ViewData["responsables"] = responsables;
            return View(dossier);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
        public IActionResult Edit(Dossier dossier)
        {
			if (ModelState.IsValid)
			{
				var oldDossier = _context.Dossiers.FirstOrDefault(d => d.DossierId == dossier.DossierId);
				oldDossier.ClientId = dossier.ClientId;
				oldDossier.DateOuv = dossier.DateOuv;
				oldDossier.Objet = dossier.Objet;
				oldDossier.ResponsableId = dossier.ResponsableId;
				_context.SaveChanges();
			}
			return RedirectToAction("DossierById", new { id = dossier.DossierId });
        }
    }
}
