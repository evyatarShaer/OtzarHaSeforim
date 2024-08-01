using Microsoft.EntityFrameworkCore;
using OtzarHaSeforim.Data;
using OtzarHaSeforim.Models;
using OtzarHaSeforim.ViewModel;

namespace OtzarHaSeforim.Service
{
    public class ShelfService : IShelfService
    {


        private readonly ApplicationDbContext _context;

        public ShelfService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ShelfModel> AddShelf(ShelfVM shelfVM, long id)
        {
            ShelfModel newShelf = new()
            {
                HighShelf = shelfVM.HighShelf,

                WidthShelf = shelfVM.WidthShelf,

                LibraryId = id,
            };
            await _context.Shelves.AddAsync(newShelf);
            await _context.SaveChangesAsync();
            return newShelf;
        }


        public async Task<List<ShelfModel>> GetLibraryShelves(long id) =>
            await _context.Shelves.Where(shelf => shelf.LibraryId == id).Include(shelf => shelf.SetBooks)
           .ThenInclude(setBooks => setBooks.Books)
           .ToListAsync();
    }
}
