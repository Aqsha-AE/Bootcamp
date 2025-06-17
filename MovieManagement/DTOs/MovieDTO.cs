namespace MovieManagement.DTOs; 
public class MovieDTO
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public int ReleaseYear { get; set; }
    public int Stock { get; set; }
    public ICollection<int>? GenreIds { get; set; } 
}