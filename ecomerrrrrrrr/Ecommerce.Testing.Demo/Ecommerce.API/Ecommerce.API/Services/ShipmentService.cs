using Ecommerce.API.Models;
namespace Ecommerce.API.Services
{   
    public class ShipmentService : IShipmentService
    {
        public void ArrangeShipment(Address address)
        {
            //Address Validation 
            if (string.IsNullorEmpty(address.Street) ||
            string.IsNullorEmpty(address.City) ||
            string.IsNullorEmpty(address.PostalCode) ||
            string.IsNullorEmpty(address.Country))
                return false;
            
            //
        }
    }

}