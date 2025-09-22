using Microsoft.EntityFrameworkCore;
using PersonalLibraryAPI.Model;

namespace PersonalLibraryAPI.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "The Clean Code", Author = "Robert C. Martin", Category = "Programming", Status = ReadingStatus.Completed, Rating = 5 },
                new Book { Id = 2, Title = "Harry Potter and the Philosopher's Stone", Author = "J.K. Rowling", Category = "Fantasy", Status = ReadingStatus.Reading, Rating = 4 },
                new Book { Id = 3, Title = "To Kill a Mockingbird", Author = "Harper Lee", Category = "Classic", Status = ReadingStatus.NotStarted }
            );
        }
    }
}