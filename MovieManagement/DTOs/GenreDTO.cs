using MovieManagement.Models;

namespace MovieManagement.DTOs;

public class GenreDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<Movie>? Movies { get; set; }
}