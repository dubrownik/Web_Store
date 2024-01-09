using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Store.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public List<CartEntry> CartEntries { get; set; }
        
        public string? UserId { get; set; }
        public virtual ApplicationUser User { get; set; } = null!;
    }
}