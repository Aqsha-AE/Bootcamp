using System.ComponentModel.DataAnnotations;

namespace MovieManagement.DTOs;

public class StockTransactionUpdateDTO
{
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
    public int Stock { get; set; }
}