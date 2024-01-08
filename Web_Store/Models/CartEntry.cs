namespace Web_Store.Models
{
    public class CartEntry
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public int Quantity { get; set; }
        
        public virtual Product Product { get; set; }
    }
}
