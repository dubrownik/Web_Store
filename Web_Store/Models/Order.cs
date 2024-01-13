using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web_Store.Models.Enums;

namespace Web_Store.Models
{
	public class Order
	{
		[Display(Name = "Numer zamówienia")]
		public int Id { get; set; }

		[ForeignKey(nameof(Buyer))]
		public string? BuyerId { get; set; }
        public virtual ApplicationUser Buyer { get; set; } = null!;

        public virtual List<OrderEntry> OrderEntries { get; set; }

		[Display(Name = "Adres")]
		public string Address { get; set; }

		public OrderStatus Status { get; set; }

        [Display(Name = "Cena zamówienia")]
        public decimal? OrderPrice => OrderEntries?.Sum(x => x.UnitPriceAtPurchase * x.Quantity);
    }
}
