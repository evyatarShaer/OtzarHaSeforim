using OtzarHaSeforim.Models;
using OtzarHaSeforim.ViewModel;

namespace OtzarHaSeforim.Service
{
    public interface ILibraryService
    {
        Task<List<LibraryModel>> GetLibraries();

        LibraryModel AddLibrary(LibraryVM library);

        LibraryModel Delete1(long id);
    }
}
