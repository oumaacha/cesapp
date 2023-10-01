using cesapp.Context;
using cesapp.Models;
using cesapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cesapp.Controllers
{
    public class ChantierController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ISessionsHandler _sessionsHandler;
        public ChantierController(ApplicationDbContext context, ISessionsHandler sessionsHandler)
        {
            _context = context;
            _sessionsHandler = sessionsHandler;
        }
        public IActionResult Index()
        {
            IEnumerable<Chantier> chantiers = _context.Chantiers.Include(x => x.Localisation.Prefecture);
            var user = _sessionsHandler.getUserSession("connectedUser");
            ViewData["userRole"] = user.RoleId;
            return View(chantiers);
        }
        [Route("/Chantier/ChefLieur/{id}")]
        public IEnumerable<Prefecture> getPrefectures(int id)
        {
            var prefectures = _context.Prefectures.Where(x => x.ChefLieu.LieuId == id);
            return prefectures;
        }
        public IActionResult Create()
        {
            var user = _sessionsHandler.getUserSession("connectedUser");
            if(user.RoleId == 1)
            {
                var cheflieux = _context.ChefLieux;
                var dossiers = _context.Dossiers.Where(d => d.Chantiers.Count <= 0);
                ViewData["cheflieux"] = cheflieux;
                ViewData["dossiers"] = dossiers;
                return View();
            }
            return Content("Accès refusée");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Chantier chantier) {

            if (ModelState.IsValid)
            {
                Localisation localisation = new Localisation()
                {
                    X = chantier.Localisation.X,
                    Y = chantier.Localisation.Y,
                    PrefectureId = int.Parse(chantier.Localisation.Prefecture.PrefectureName)
                };
                _context.Localisations.Add(localisation);
                _context.SaveChanges();
                
                Chantier newChantier = new Chantier()
                {
                    Budget = chantier.Budget,
                    ChantierName = chantier.ChantierName,
                    Progres = chantier.Progres,
                    DateDebut = chantier.DateDebut,
                    DateFin = chantier.DateFin,
                    Description = chantier.Description,
                    LocalisationId = localisation.LocalisationId,
                    DossierId = chantier.DossierId
                };
                _context.Chantiers.Add(newChantier);
                _context.SaveChanges();
            }
            else
            {
                var cheflieux = _context.ChefLieux;
                ViewData["cheflieux"] = cheflieux;
                return View();
            }
            return RedirectToAction("Index","Chantier");
        }
        [Route("/Chantier/Chantier/{id}")]
        public IActionResult Chantier(int id)
        {
            var chantier = _context.Chantiers
                .Include(x => x.Localisation.Prefecture)
                .Include(x => x.Machines)
				.Include(x => x.Dossier)
				.FirstOrDefault(x => x.ChantierId == id);
			var user = _sessionsHandler.getUserSession("connectedUser");
			ViewData["userRole"] = user.RoleId;
			return View(chantier);
        }
        public IActionResult AffecterMachine(int id)
        {
            var chantier = _context.Chantiers.FirstOrDefault(c => c.ChantierId == id);
            if(chantier != null)
            {
				return View(chantier);
			}
            return Content("le Chantier n'est pas trouvé !");
        }
        [Route("/Chantier/GetMachinesByDesignation")]
        public IEnumerable<Machine> GetMachinesByDesignation()
        {
            var designation = Request.Query["D"];
            var pattern = "%" + designation + "%";
            var machines = _context.Machines.Where(m => (m.isAvailable && EF.Functions.ILike(m.Designation, pattern)));
            return machines;
        }

		[Route("/Chantier/AffecterMachineChantier/{chantierid}")]
		public IActionResult AffecterMachineChantier(int chantierid)
        {
            int machineId = int.Parse(Request.Query["machine"]);
            var machine = _context.Machines.FirstOrDefault(m => m.MachineId == machineId);
            if(machine != null)
            {
                try
                {
					machine.ChantierId = chantierid;
                    machine.isAvailable = false;
					_context.SaveChanges();

				}catch(Exception ex)
                {
                    return Content("Error en database");
                }
				return Json(new { message = "done" });
            }
			return Json(new { message = "error" });
		}
        public IActionResult Edit(int id)
        {
            var chantier = _context.Chantiers
                .Include(c => c.Dossier)
                .Include(c => c.Localisation.Prefecture.ChefLieu)
                .FirstOrDefault(c => c.ChantierId == id);
            IEnumerable<ChefLieu> cheflieux = _context.ChefLieux;
            IEnumerable<Dossier> dossiers = _context.Dossiers;
            ViewData["cheflieux"] = cheflieux;
            ViewData["dossiers"] = dossiers;
            return View(chantier);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Chantier chantier)
        {
            if (ModelState.IsValid)
            {
                var oldChantier = _context.Chantiers.FirstOrDefault(c => c.ChantierId == chantier.ChantierId);
                if (oldChantier != null)
                {
                    oldChantier.Progres = chantier.Progres;
                    oldChantier.Budget = chantier.Budget;
                    oldChantier.DateDebut = chantier.DateDebut;
                    oldChantier.DateFin = chantier.DateFin;
                    oldChantier.Description = chantier.Description;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Chantier", new { id = chantier.ChantierId });
        }
    }
}
