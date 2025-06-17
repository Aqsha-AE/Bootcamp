namespace MovieManagement.Models;

public class StockTransaction
{
    public enum TransactionType
    {
        In,
        Out
    }
    public int Id { get; set; }
    public TransactionType Transaction { get; set; }
    public int MovieId { get; set; }
    public Movie? Movie { get; set; }
    public int Quantity { get; set; }
    public DateTime Date { get; set; }
}