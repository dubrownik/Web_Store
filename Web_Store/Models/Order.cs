namespace Web_Store.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public List<OrderEntry> OrderEntries { get; set; }
        public string Address { get; set; }
    }
}
