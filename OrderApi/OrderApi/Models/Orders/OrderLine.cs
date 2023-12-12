namespace OrderApi.Models.Orders
{
    public class OrderLine : Entity
    {
        public Guid OrderId { get; set; }
        public int LineNumber { get; set; }
        public string ItemCode { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }

        public Order Order { get; set; }
    }
}
