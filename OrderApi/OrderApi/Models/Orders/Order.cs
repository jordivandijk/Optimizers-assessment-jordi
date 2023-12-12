using OrderApi.Models.Security;

namespace OrderApi.Models.Orders
{
    public class Order : Entity
    {
        public int OnderNumber { get; set; }
        public DateTime OndetDate { get; set; }
        public string Reference { get; set; }
        public string CustomerName { get; set; }
        public Guid UserId { get; set; }

        public ICollection<OrderLine> OrderLines { get; set; }
        public User User { get; set; }
    }
}
