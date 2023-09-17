using cesapp.Context;
using cesapp.Models;  
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using cesapp.Services;
using X.PagedList.Mvc.Core;
using X.PagedList;

namespace cesapp.Controllers
{
    public class MachineController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IExcelFileHandler _excelFileHandler;
        public MachineController(ApplicationDbContext context, IExcelFileHandler excelFileHandler)
        {
            _context = context;
            _excelFileHandler = excelFileHandler;
        }
        public IActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
			int pageSize = 9;
            var machines = _context.Machines
                .ToPagedList(pageNumber, pageSize);
            return View(machines);
        }
        public IActionResult Create()
        {
            IEnumerable<Fournisseur> fournisseurs = _context.Fournisseurs;
            IEnumerable<MachineType> machineTypes = _context.MachineTypes;
            IEnumerable<Operateur> operateurs = _context.Operateurs.Where(o => o.isAvailable == true);
            ViewData["fournisseurs"] = fournisseurs;
            ViewData["machineTypes"] = machineTypes;
            ViewData["operateurs"] = operateurs;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.Machine machine) {

            if (ModelState.IsValid)
            {
                var maxIdMachine = _context.Machines.Max(M => M.MachineId);
                var r = Request.Form["selectedFournisseur"];
                var newMachine = new Models.Machine()
                {
                    MachineId = maxIdMachine + 1,
                    Designation = machine.Designation,
                    DateAcquisition = machine.DateAcquisition,
                    Nfacteur = machine.Nfacteur,
                    FournisseurId = 0,
                    MachineTypeId = 0,
                    ChantierId = null,
                    OperateurId = int.Parse(Request.Form["selectedOperateur"])
                };
                if (Request.Form["selectedFournisseur"] == "autre")
                { 
                    _context.Fournisseurs.Add(machine.Fournisseur);
                    _context.SaveChanges();
                    var maxId = _context.Fournisseurs.Max(F => F.FournisseurId);
                    newMachine.FournisseurId = maxId;
                }
                else
                {
                    int FournisseurId = int.Parse(Request.Form["selectedFournisseur"]);
                    newMachine.FournisseurId = FournisseurId;
                }
                if (Request.Form["selectedMachineType"] == "autre")
                {
                    _context.MachineTypes.Add(machine.MachineType);
                    _context.SaveChanges();
                    var maxId = _context.MachineTypes.Max(M => M.MachineTypeId);
                    newMachine.MachineTypeId = maxId;
                }
                else
                {
                    int MachineTypeId = int.Parse(Request.Form["selectedMachineType"]);
                    newMachine.MachineTypeId = MachineTypeId;
                }

                _context.Machines.Add(newMachine);
                _context.SaveChanges();

                var operateur = _context.Operateurs.Find(newMachine.OperateurId);
                operateur.isAvailable = false;
                _context.SaveChanges();

            }
            return RedirectToAction("Index", "Machine");
        }
        public IActionResult MachineById(int id)
        {
            var machine = _context.Machines
                .Include(M => M.Chantier)
                .Include(M => M.MachineType)
                .Include(M => M.Fournisseur)
                .Include(M => M.Operateur)
                .FirstOrDefault(m => m.MachineId == id);
            return View(machine);
        }
        public IActionResult Delete(int id)
        {
            var machine = _context.Machines.SingleOrDefault(m => m.MachineId == id);
            if (machine == null)
            {
                return Content("machine not found");
            }
            _context.Machines.Remove(machine);
            _context.SaveChanges();
            return RedirectToAction("Index", "Machine");
        }

        public IActionResult AddMachinesUsingFile()
        {
            return View();
        }

		[HttpPost]
        [ValidateAntiForgeryToken]
		public ActionResult UploadFile(IFormFile file)
		{
			if (file != null && file.Length > 0)
			{
				using (var package = new ExcelPackage(file.OpenReadStream()))
				{
					ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    int lineError= _excelFileHandler.fileValidation(worksheet);
                    if (lineError == 0)
                    {
                        _excelFileHandler.insertInDatabase(worksheet);
                        return Content("file valide");
                    }
                    else
                    {
						return Content("Le format des données est invalide à la ligne "+lineError);
					}
				}
			}

            return Content(file.FileName);
		}
	}
}
