using OtzarHaSeforim.Models;
using OtzarHaSeforim.ViewModel;

namespace OtzarHaSeforim.Service
{
    public interface ISetBooksService
    {
        Task<List<SetBooksModel>> GetAllSetBooks(long id);

        Task<SetBooksModel> AddSetBooks(SetBooksVM setBooksVM, long id);
    }
}
