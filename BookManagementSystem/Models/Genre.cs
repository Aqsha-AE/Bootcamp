using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BookManagementSystem.Models;

public class Genre
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();
}