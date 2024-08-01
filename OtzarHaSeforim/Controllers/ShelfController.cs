using Microsoft.AspNetCore.Mvc;
using OtzarHaSeforim.Data;
using OtzarHaSeforim.Models;
using OtzarHaSeforim.Service;
using OtzarHaSeforim.ViewModel;

namespace OtzarHaSeforim.Controllers
{
    public class ShelfController : Controller
    {

        private readonly ApplicationDbContext _context;

        private readonly IShelfService _ShelfService;


        public ShelfController(ApplicationDbContext context, IShelfService shelfService)
        {
            _context = context;
            _ShelfService = shelfService;

        }
        public async Task<IActionResult> Index(long id) {
            ViewBag.Id = id;

            return View(await _ShelfService.GetLibraryShelves(id));
        }

        public IActionResult Create(long id)
        {
            ViewBag.Id = id;

            return View(new ShelfVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ShelfVM shelfVM, long id)
        {
            ViewBag.Id = id;

            await _ShelfService.AddShelf(shelfVM, id);
            return RedirectToAction("Index", new {id = ViewBag.Id });
        }
    }
}
