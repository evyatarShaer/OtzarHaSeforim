using Microsoft.EntityFrameworkCore;
using OtzarHaSeforim.Data;
using OtzarHaSeforim.Models;
using OtzarHaSeforim.ViewModel;

namespace OtzarHaSeforim.Service
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BookModel> AddBook(BookVM bookVM, long id)
        {
            BookModel? BookModel = new()
            {
                BookName = bookVM.BookName,
                HighBook = bookVM.HighBook,
                WidthBook = bookVM.WidthBook,
                GenreBook = bookVM.GenreBook,
                SetBooksId = id,
            };
            await _context.Books.AddAsync(BookModel);
            await _context.SaveChangesAsync();
            return BookModel;
        }

        public async Task<List<BookModel>> GetAllBooks(long id) =>
            await _context.Books.Where(book => book.SetBooksId == id)
                   .ToListAsync();
    }
}
