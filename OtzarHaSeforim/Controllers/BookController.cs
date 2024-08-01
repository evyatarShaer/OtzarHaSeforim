using Microsoft.AspNetCore.Mvc;
using OtzarHaSeforim.Data;
using OtzarHaSeforim.Service;
using OtzarHaSeforim.ViewModel;

namespace OtzarHaSeforim.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IBookService _bookService;

        public BookController(ApplicationDbContext context, IBookService bookService)
        {
            _context = context;
            _bookService = bookService;
        }
        public async Task<IActionResult> Index(long id)
        {
            ViewBag.Id = id;
            return View(await _bookService.GetAllBooks(id));
        }

        public IActionResult Create(long id)
        {
            ViewBag.Id = id;

            return View(new BookVM());
        }


        [HttpPost]
        public async Task<IActionResult> Create(BookVM bookVM, long id)
        {
            ViewBag.Id = id;

            await _bookService.AddBook(bookVM, id);
            return RedirectToAction("Index", new { id = ViewBag.Id });
        }
    }
}
