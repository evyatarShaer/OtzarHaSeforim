using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtzarHaSeforim.Data;
using OtzarHaSeforim.Models;
using OtzarHaSeforim.ViewModel;

namespace OtzarHaSeforim.Service
{
    public class LibraryService : ILibraryService
    {
        private readonly  ApplicationDbContext _context;

        public LibraryService(ApplicationDbContext context)
        {
            _context = context;
        }


        
        public LibraryModel AddLibrary(LibraryVM libraryVM)
        {
            LibraryModel? existingLibrary = _context.Libraries
                .FirstOrDefault(library => library.GenreLibrary == libraryVM.GenreLibrary);

            if (existingLibrary != null)
            {
                throw new Exception($"Genre '{libraryVM.GenreLibrary}' already exists.");
            }

            LibraryModel newLibrary = new()
            {
                GenreLibrary = libraryVM.GenreLibrary,
            };
            _context.Libraries.Add(newLibrary);
            _context.SaveChanges();
            return newLibrary;
        }

        public async Task<List<LibraryModel>> GetLibraries() =>
            await _context.Libraries.Include(library => library.Shelves)
            .ThenInclude(shelf => shelf.SetBooks)
            .ThenInclude(setBooks => setBooks.Books)
            .ToListAsync();

                
        public LibraryModel Delete1(long Id)
        {
            LibraryModel? toDelete = _context.Libraries.Find(Id);

            if (toDelete != null)
            {
                _context.Libraries.Remove(toDelete);
                _context.SaveChanges();
            }
            return toDelete;
        }
    }
}
