using Microsoft.AspNetCore.Identity;
using Web_Store.Models.Enums;

namespace Web_Store.Models
{  

    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserType UserType { get; set; }

        public List<Cart> Cart { get; set; } = new List<Cart>();
    }
}

