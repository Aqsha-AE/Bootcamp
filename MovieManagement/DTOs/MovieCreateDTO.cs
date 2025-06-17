using System.ComponentModel.DataAnnotations;

namespace MovieManagement.DTOs;

public class MovieCreateDTO
{
    [Required(ErrorMessage = "Title is required.")]
    public string? Title { get; set; }

    [Range(1900, 2100)]
    public int ReleaseYear { get; set; }

    [Required]
    public ICollection<int>? GenreIds { get; set; } 
    
    public int Stock { get; set; } 
}