using Microsoft.EntityFrameworkCore;
using OtzarHaSeforim.Data;
using OtzarHaSeforim.Models;
using OtzarHaSeforim.ViewModel;

namespace OtzarHaSeforim.Service
{
    public class SetBooksService : ISetBooksService
    {
        private readonly ApplicationDbContext _context;

        public SetBooksService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SetBooksModel> AddSetBooks(SetBooksVM setBooksVM, long id)
        {
            SetBooksModel? setBooksModel = new()
            {
                Title = setBooksVM.Title,
                ShelfId = id,
            };
            await _context.Sets.AddAsync(setBooksModel);
            await _context.SaveChangesAsync();
            return setBooksModel;
        }

        public async Task<List<SetBooksModel>> GetAllSetBooks(long id) =>
            await _context.Sets.Where(set => set.ShelfId == id)
                    .Include(setBooks => setBooks.Books)
                    .ToListAsync();

    }
}
