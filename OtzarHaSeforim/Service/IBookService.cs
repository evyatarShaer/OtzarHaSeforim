using OtzarHaSeforim.Models;
using OtzarHaSeforim.ViewModel;

namespace OtzarHaSeforim.Service
{
    public interface IBookService
    {
        Task<List<BookModel>> GetAllBooks(long id);

        Task<BookModel> AddBook(BookVM book, long id);
    }
}
