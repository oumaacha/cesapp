using cesapp.Context;
using cesapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace cesapp.Controllers
{
    public class ConsommationController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ConsommationController(ApplicationDbContext context)
        {
            _context = context;
        }
        /*public IActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 3;

            var consommations = _context.Consommations
                .ToPagedList(pageNumber, pageSize);

            IEnumerable<Consommation> data = _context.Consommations
                .Include(c => c.Machine)
                .Include(c => c.consommationType)
                .Include(c => c.Operateur);
            return View(data);
        }*/
        public IActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 3;

            /*var consommationsPages = _context.Consommations
                .ToPagedList(pageNumber, pageSize);*/

            IEnumerable<Consommation> consommations = _context.Consommations
                .Include(c => c.Machine)
                .Include(c => c.consommationType)
                .Include(c => c.Operateur);
                
            return View(consommations);
        }
        public IActionResult Create(int id)
        {
            var machine = _context.Machines.Include(m => m.Operateur).FirstOrDefault(m => m.MachineId == id);
            ViewData["consommationTypes"] = _context.ConsommationsType;
            ViewData["operateurs"] = _context.Operateurs;
            ViewData["machine"] = machine;
			return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Consommation consommation)
        {
            if(ModelState.IsValid)
            {
                var Machine = _context.Machines.Include(m => m.Operateur).FirstOrDefault(m => m.MachineId == consommation.MachineId);
                var howManyConsommationInDb = _context.Consommations.Count();
                var maxConsommatioId = 1;
				if (howManyConsommationInDb > 0)
                {
                    maxConsommatioId = _context.Consommations.Max(c => c.ConsommationId);
                }
                var newCosommation = new Consommation()
                {
                    ConsommationId = maxConsommatioId+1,
                    ConsommationTypeId = consommation.ConsommationTypeId,
                    MachineId = Machine.MachineId,
                    MontantEnDh = consommation.MontantEnDh,
                    OperateurId = Machine.OperateurId,
                    Date = consommation.Date
                };
                _context.Consommations.Add(newCosommation);
                _context.SaveChanges();
			}
            return RedirectToAction("Index","Consommation");
        }
        public IDictionary<string,decimal> MachineConsommationDataById(int id)
        {
            var data = _context.Consommations
                .Where(c => c.MachineId == id)
                .GroupBy(c => c.consommationType.Type)
                .ToDictionary(
                    group => group.Key,
                    group => group.Sum(c => c.MontantEnDh)
                ); 
            return data;
        }

		public IDictionary<string, decimal> MachineConsommationDataByIdBars(int id)
		{
			var data = _context.Consommations
				.Where(c => c.MachineId == id)
				.GroupBy(c => new { Month = c.Date.Month, Type = c.consommationType.Type })
				.ToDictionary(
					group => $"{group.Key.Month}_{group.Key.Type}",
					group => group.Sum(c => c.MontantEnDh)
				);

			return data;
		}

	}
}
