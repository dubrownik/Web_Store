namespace Web_Store.Models
{
    public class OrderEntry
    {
        public int Id { get; set; }
        public string ProductNameAtPurchase { get; set; }
        public decimal UnitPriceAtPurchase { get; set; }
        public int Quantity { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
