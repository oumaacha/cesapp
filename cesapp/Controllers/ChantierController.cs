using cesapp.Context;
using cesapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cesapp.Controllers
{
    public class ChantierController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ChantierController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Chantier> chantiers = _context.Chantiers.Include(x => x.Localisation.Prefecture);
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
            var cheflieux = _context.ChefLieux;
            ViewData["cheflieux"] = cheflieux;
            return View();
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
                    LocalisationId = localisation.LocalisationId
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
    }
}
