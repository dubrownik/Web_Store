using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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

        public int CategoryId { get; set; }

        [Display(Name = "Cena")]
        public decimal Price { get; set; }


        [ForeignKey(nameof(Seller))]
        [ValidateNever]
        public string SellerId { get; set; }

        [ValidateNever]
        public virtual ApplicationUser Seller { get; set; }
        
        public string? PictureLink { get; set; }

        [NotMapped]
        [Display(Name = "Zdjęcie")]
        public IFormFile? PictureFile { get; set; }

        public virtual Category? Category { get; set; } = null!;
    }
}
