using System.ComponentModel.DataAnnotations;
using PersonalLibraryAPI.Model;

namespace PersonalLibraryAPI.DTOs
{
    public class BookCreateDTo
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Author { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Category { get; set; } = string.Empty;

        public string? Description { get; set; }
    }

    public class BookUpdateDT : BookCreateDTo
    {
        public ReadingStatus Status { get; set; }
        public int? Rating { get; set; }
    }

    public class BookDTo
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public ReadingStatus Status { get; set; }
        public DateTime DateAdded { get; set; }
        public string? Description { get; set; }
        public int? Rating { get; set; }
    }
}