namespace Ecommerce.API.Models
{
    public class Order
    {
        public string Id { get; set; }
        public List<CartItem> Items { get; set; }
        public Card PaymentCard { get; set; }
        public Address ShippingAddress { get; set; }
        public int TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
    }

    public class CartItem
    {
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

    }

    public class Card
    {
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }

    public enum OrderStatus
    {
        Pending,
        Confirmed,
        Shipped, 
        Delivered
    }
}

