namespace Web_Store.Models
{
    public class OrderEntry
    {
        public int Id { get; set; }
        public string ProductNameAtPurchase { get; set; }
        public int PriceAtPurchase { get; set; }
        public int Quantity { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
