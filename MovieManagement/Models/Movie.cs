namespace MovieManagement.Models;

public class Movie
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public int ReleaseYear { get; set; }
    public int StockQuantity { get; set; } 
    public List<MovieGenre> ? MovieGenres { get; set; } 
    public List<StockTransaction>? StockTransactions { get; set; }
}