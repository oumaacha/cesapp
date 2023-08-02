using cesapp.Context;
using cesapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace cesapp.Controllers
{
    public class MachineController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MachineController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Machine> machines = _context.Machines;
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
        public IActionResult Create(Machine machine) {

            if (ModelState.IsValid)
            {
                var maxIdMachine = _context.Machines.Max(M => M.MachineId);
                var r = Request.Form["selectedFournisseur"];
                var newMachine = new Machine()
                {
                    MachineId = maxIdMachine + 1,
                    Designation = machine.Designation,
                    DateAcquisition = machine.DateAcquisition,
                    Nfacteur = machine.Nfacteur,
                    FournisseurId = 0,
                    MachineTypeId = 0,
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
            }
            return RedirectToAction("Index", "Home");
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
    }
}
