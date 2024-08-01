using OtzarHaSeforim.Models;

namespace OtzarHaSeforim.ViewModel
{
    public class SetBooksVM
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public long ShelfId { get; set; }

        public ShelfModel ShelfParent { get; set; }

        public List<BookModel> Books { get; set; } = [];
    }
}
