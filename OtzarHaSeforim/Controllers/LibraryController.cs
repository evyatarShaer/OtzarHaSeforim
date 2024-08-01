using Microsoft.AspNetCore.Mvc;
using OtzarHaSeforim.Data;
using OtzarHaSeforim.Models;
using OtzarHaSeforim.Service;
using OtzarHaSeforim.ViewModel;


namespace OtzarHaSeforim.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly ILibraryService _libraryService;

        public LibraryController(ApplicationDbContext context, ILibraryService libraryService)
        {
            _context = context;
            _libraryService = libraryService;

        }
        public IActionResult Index() =>
             View(_context.Libraries.ToList());

        public IActionResult Create() => View(new LibraryVM());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LibraryVM libraryVM)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            try
            {
                LibraryModel? value = _libraryService.AddLibrary(libraryVM);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("createError", ex.Message);
                return View();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(long id)
        {
            _libraryService.Delete1(id);
            return RedirectToAction("Index");
        }
    }
}







































//object strin = "lkhl";
//object x = null;

//// value check
//if (x == null)
//{
//}

//// type check
//if (strin is string str)
//{
//    str.ToUpper();
//}



