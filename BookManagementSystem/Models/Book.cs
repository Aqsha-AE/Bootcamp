using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic; 
namespace BookManagementSystem.Models;

public class Book
{
    public int Id { get; set; }

    [StringLength(100)]
    public string? Title { get; set; }

    [StringLength(800)]
    public string? Description { get; set; }
    public string? Author { get; set; }
    public DateTime PublishedDate { get; set; }

    //navigation relationships
    public ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();
    public ICollection<Stock>? Stocks { get; set; }
}