namespace ContosoPizza.Models
{
    public class OrderDetail //many to many relationships
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int Orderid { get; set; }
        public int Productid { get; set; }
        public Order Order { get; set; } = null!;
        public Product? Product { get; set; } = null!;

    }  
}