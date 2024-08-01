using OtzarHaSeforim.Models;
using System.ComponentModel.DataAnnotations;

namespace OtzarHaSeforim.ViewModel
{
    public class LibraryVM
    {
        public long Id { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "Genre library Should bein a range of 2 - 100")]
        public string GenreLibrary { get; set; } = string.Empty;

        public List<ShelfModel> Shelves { get; set; } = [];
    }
}
