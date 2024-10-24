namespace CustomerOrderDetails.Models.Entities
{
    public class Orders
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryExepected { get; set; }
        public bool ContainsGift { get; set; }

    }
}
