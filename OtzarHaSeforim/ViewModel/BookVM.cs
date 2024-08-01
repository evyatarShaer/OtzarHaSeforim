﻿using OtzarHaSeforim.Models;
using System.ComponentModel.DataAnnotations;

namespace OtzarHaSeforim.ViewModel
{
    public class BookVM
    {
        public long Id { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "Book name Should bein a range of 3 - 100")]
        public string BookName { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "Genre book Should bein a range of 3 - 100")]
        public string GenreBook { get; set; }

        [Range(10, 50, ErrorMessage = "The value must be between 10 and 50")]
        public int HighBook { get; set; }

        [Range(1, 20, ErrorMessage = "The value must be between 10 and 50")]
        public int WidthBook { get; set; }

        public long SetBooksId { get; set; }

        public SetBooksModel SetBooksParent { get; set; }
    }
}
