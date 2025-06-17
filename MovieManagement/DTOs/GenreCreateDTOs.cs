using System.ComponentModel.DataAnnotations;

namespace MovieManagement.DTOs;

public class GenreCreateDTO
{
    [Required(ErrorMessage = "Genre name is required")]
    [StringLength(100, ErrorMessage = "Genre name cannot exceed 100 characters")]
    public string? Name { get; set; }
}