namespace ContosoPizza.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!; 
        public decimal Price { get; set; }   
    }
}