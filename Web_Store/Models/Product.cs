using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Store.Models
{
    public class Product 
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        //public int CategoryId { get; set; }
        [Display(Name = "Cena")]
        public decimal Price { get; set; }

        [ForeignKey(nameof(Seller))]
        public string SellerId { get; set; }
        public virtual ApplicationUser Seller { get; set; }

        //public int Picture { get; set; }
    }
}
