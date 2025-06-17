using System.ComponentModel.DataAnnotations;

namespace MovieManagement.DTOs;

public class MovieUpdateDTO
{
    [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Title { get; set; }

        [Range(1900, 2100)]
        public int ReleaseYear { get; set; }

        [Range(0, 1000)]
        public decimal Price { get; set; }

        public List<int> GenreIds { get; set; } = new List<int>();

}