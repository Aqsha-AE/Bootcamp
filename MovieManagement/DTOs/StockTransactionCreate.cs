using System.ComponentModel.DataAnnotations;

namespace MovieManagement.DTOs;

public class StockTransactionCreateDTO
{
    [Required]
    public string? TransactionType { get; set; }

    [Required]
    public int MovieId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
    public int Stock { get; set; } 
}