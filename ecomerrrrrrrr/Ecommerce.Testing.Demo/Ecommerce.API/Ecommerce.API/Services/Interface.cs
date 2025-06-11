using Ecommerce.API.Models;
namespace Ecommerce.API.Services
{
    public interface ICartService
    {
        public string CheckoutCart(Order order);
    }

    public interface IPaymentService
    {
        public string Charge(Order order);
        public bool MakePayment(Card card);
    }
    
    public interface IShipmentService
    {
        public void ArrangeShipment(Address address);
    }

}