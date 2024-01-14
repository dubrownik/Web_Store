using System.ComponentModel.DataAnnotations;

namespace Web_Store.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
    }
}
