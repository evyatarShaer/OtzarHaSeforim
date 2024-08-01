using Microsoft.AspNetCore.Mvc;
using OtzarHaSeforim.Data;
using OtzarHaSeforim.Service;
using OtzarHaSeforim.ViewModel;

namespace OtzarHaSeforim.Controllers
{
    public class SetBooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly ISetBooksService _setBooksService;

        public SetBooksController(ApplicationDbContext context, ISetBooksService setBooksService)
        {
            _context = context;
            _setBooksService = setBooksService;
        }

        public async Task<IActionResult> Index(long id)
        {
            ViewBag.Id = id;

            return View(await _setBooksService.GetAllSetBooks(id));
        }

        public IActionResult Create(long id)
        {
            ViewBag.Id = id;

            return View(new SetBooksVM());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SetBooksVM setBooksVM, long id)
        {
            ViewBag.Id = id;

            await _setBooksService.AddSetBooks(setBooksVM, id);
            return RedirectToAction("Index", new { id = ViewBag.Id });
        }
    }
}
