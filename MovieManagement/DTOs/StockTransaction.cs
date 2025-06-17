namespace MovieManagement.DTOs;
using MovieManagement.Models;
public class StockTransactionDTO
{
    public int Id { get; set; }
    public StockTransaction.TransactionType Type { get; set; }
    public int MovieId { get; set; }
    public string? MovieTitle { get; set; }
    public DateTime Date { get; set; }
}