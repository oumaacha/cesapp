using cesapp.Context;
using cesapp.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace cesapp.Controllers
{
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ClientController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 2;
            var clients = _context.Clients
                .ToPagedList(pageNumber, pageSize);
            return View(clients);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                if(client != null)
                {
                    _context.Clients.Add(client);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index","Client");
        }

        public IActionResult Delete(int id)
        {
            var clients = _context.Clients.Find(id);
            if (clients != null)
            {
                _context.Clients.Remove(clients);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Client");
        }
    }
}
