using System.ComponentModel.DataAnnotations;

namespace Web_Store.Models
{
    public class CartEntry
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        [Range(1, int.MaxValue)]
		[Display(Name = "Ilość")]
		public int Quantity { get; set; }
        
        public virtual Product Product { get; set; }

        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
