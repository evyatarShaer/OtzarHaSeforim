using Microsoft.EntityFrameworkCore;
using OtzarHaSeforim.Models;
using System;

namespace OtzarHaSeforim.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
            
        }

        public DbSet<LibraryModel> Libraries { get; set; }
        public DbSet<ShelfModel> Shelves { get; set; }
        public DbSet<SetBooksModel> Sets { get; set; }
        public DbSet<BookModel> Books { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LibraryModel>()
                .HasMany(library => library.Shelves)
                .WithOne(shelf => shelf.LibraryParent)
                .HasForeignKey(shelf => shelf.LibraryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ShelfModel>()
                .HasMany(shelf => shelf.SetBooks)
                .WithOne(setBooks => setBooks.ShelfParent)
                .HasForeignKey(setBooks => setBooks.ShelfId)  
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SetBooksModel>()
                .HasMany(setBooks => setBooks.Books)
                .WithOne(book => book.SetBooksParent)
                .HasForeignKey(book => book.SetBooksId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
