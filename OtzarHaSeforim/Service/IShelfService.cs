using OtzarHaSeforim.Models;
using OtzarHaSeforim.ViewModel;

namespace OtzarHaSeforim.Service
{
    public interface IShelfService
    {
        Task<List<ShelfModel>> GetLibraryShelves(long id);

        Task<ShelfModel> AddShelf(ShelfVM shelf, long id);

    }
}
