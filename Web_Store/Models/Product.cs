using System.ComponentModel.DataAnnotations;

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

        // public int SellerId { get; set; }

        //public int Picture { get; set; }


    }
}
