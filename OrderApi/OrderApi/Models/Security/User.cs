using OrderApi.Models.Orders;

namespace OrderApi.Models.Security
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
