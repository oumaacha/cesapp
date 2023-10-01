using cesapp.Context;
using cesapp.Models;  
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using cesapp.Services;
using X.PagedList.Mvc.Core;
using X.PagedList;
using DocumentFormat.OpenXml.Spreadsheet;

namespace cesapp.Controllers
{
    public class MachineController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ISessionsHandler _sessionsHandler;
        private readonly IExcelFileHandler _excelFileHandler;
        public MachineController(ApplicationDbContext context, ISessionsHandler sessionsHandler , IExcelFileHandler excelFileHandler)
        {
            _context = context;
            _excelFileHandler = excelFileHandler;
			_sessionsHandler = sessionsHandler;

		}
        public IActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
			int pageSize = 9;
            var machines = _context.Machines
				.Include(m => m.Operateur)
				.OrderByDescending(m => m.DateAcquisition)
                .ToPagedList(pageNumber, pageSize);
            var user = _sessionsHandler.getUserSession("connectedUser");
            ViewData["userRole"] = user.RoleId;
            return View(machines);
        }
        public IActionResult Create()
        {
			var user = _sessionsHandler.getUserSession("connectedUser");
            if(user.RoleId == 1)
            {
				IEnumerable<Fournisseur> fournisseurs = _context.Fournisseurs;
				IEnumerable<MachineType> machineTypes = _context.MachineTypes;
				IEnumerable<Operateur> operateurs = _context.Operateurs.Where(o => o.isAvailable == true);
				ViewData["fournisseurs"] = fournisseurs;
				ViewData["machineTypes"] = machineTypes;
				ViewData["operateurs"] = operateurs;
				return View();
			}
            return Content("Accès refusé");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.Machine machine) {
			var user = _sessionsHandler.getUserSession("connectedUser");
            if(user.RoleId == 1)
            {
				if (ModelState.IsValid)
				{
					var maxIdMachine = _context.Machines.Max(M => M.MachineId);
					var r = Request.Form["selectedFournisseur"];
					var newMachine = new Models.Machine()
					{
						MachineId = maxIdMachine + 1,
						Designation = machine.Designation,
						DateAcquisition = machine.DateAcquisition,
                        Nfacture = machine.Nfacture,
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
            if (machine.Operateur == null)
            {
                IEnumerable<Operateur> operateurs = _context.Operateurs.Where(O => O.isAvailable == true);
                ViewData["operateurs"] = operateurs;
            }
            return View(machine);
        }
        public IActionResult Delete(int id)
        {
			var user = _sessionsHandler.getUserSession("connectedUser");
            if (user.RoleId == 1) {
				var machine = _context.Machines.SingleOrDefault(m => m.MachineId == id);
				if (machine == null)
				{
					return Content("machine not found");
				}
				_context.Machines.Remove(machine);
				_context.SaveChanges();
				return RedirectToAction("Index", "Machine");
			}
			return Content("Accès refusé");
		}

        public IActionResult AddMachinesUsingFile()
        {
			var user = _sessionsHandler.getUserSession("connectedUser");
			if (user.RoleId == 1)
			{
				return View();
			}
			return RedirectToAction("Index", "Machine");
        }

		[HttpPost]
        [ValidateAntiForgeryToken]
		public ActionResult UploadFile(IFormFile file)
		{
			var user = _sessionsHandler.getUserSession("connectedUser");
			if(user.RoleId == 1)
			{
				if (file != null && file.Length > 0)
				{
					using (var package = new ExcelPackage(file.OpenReadStream()))
					{
						ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
						int lineError = _excelFileHandler.fileValidation(worksheet);
						if (lineError == 0)
						{
							_excelFileHandler.insertInDatabase(worksheet);
							return Content("file valide");
						}
						else
						{
							return Content("Le format des données est invalide à la ligne " + lineError);
						}
					}
				}
				return Content(file.FileName);
			}
			return Content("Accès refusé");
		}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AttribuerOperateur()
        {
            var operateurId = int.Parse(HttpContext.Request.Form["OperateurId"]);
            var machineId = int.Parse(HttpContext.Request.Form["MachineId"]);
            var machine = _context.Machines.FirstOrDefault(M => M.MachineId == machineId);
            var operateur = _context.Operateurs.FirstOrDefault(O => O.OperateurId == operateurId);
			if (machine != null)
            {
                machine.OperateurId = operateurId;
                operateur.isAvailable = false;
                _context.SaveChanges();
			}
            return RedirectToAction("MachineById", new { id = machineId });
        }
		public IActionResult Edit(int id)
		{
			var machine = _context.Machines
				.Include(M => M.Fournisseur)
				.Include(M => M.MachineType)
                .FirstOrDefault(m => m.MachineId == id);
            IEnumerable<Fournisseur> fournisseurs = _context.Fournisseurs;
            IEnumerable<MachineType> machineTypes = _context.MachineTypes;
            ViewData["machineTypes"] = machineTypes;
            ViewData["fournisseurs"] = fournisseurs;
            return View(machine);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
        public IActionResult Edit(Machine machine)
        {
			if(ModelState.IsValid)
			{
				var oldMachine = _context.Machines.FirstOrDefault(M => M.MachineId == machine.MachineId);
				oldMachine.Designation = machine.Designation;
				oldMachine.Nfacture = machine.Nfacture;
				oldMachine.DateAcquisition = machine.DateAcquisition;
				oldMachine.situation = machine.situation;
				_context.SaveChanges();
            }
			return RedirectToAction("MachineById",new {id = machine.MachineId});
        }
    }
}
