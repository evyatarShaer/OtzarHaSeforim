using System.ComponentModel.DataAnnotations;

namespace OtzarHaSeforim.Models
{
    public class SetBooksModel
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public required string Title { get; set; }

        public long ShelfId { get; set; }

        public ShelfModel ShelfParent { get; set; }

        public List<BookModel> Books { get; set; } = [];
    }
}