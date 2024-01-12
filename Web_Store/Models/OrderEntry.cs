using System.ComponentModel.DataAnnotations;

namespace Web_Store.Models
{
    public class OrderEntry
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa produktu")]
        public string ProductNameAtPurchase { get; set; }

        [Display(Name = "Cena")]
        public decimal UnitPriceAtPurchase { get; set; }

        [Display(Name = "Ilość")]
        public int Quantity { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
