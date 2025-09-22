using System.ComponentModel.DataAnnotations;

namespace PersonalLibraryAPI.Model
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Author { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Category { get; set; } = string.Empty;

        public ReadingStatus Status { get; set; } = ReadingStatus.NotStarted;

        public DateTime DateAdded { get; set; } = DateTime.Now;

        [StringLength(500)]
        public string? Description { get; set; }

        public int? Rating { get; set; }
    }

    public enum ReadingStatus
    {
        NotStarted,
        Reading,
        Completed,
        OnHold
    }
}