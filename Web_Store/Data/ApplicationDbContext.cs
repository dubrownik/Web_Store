using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web_Store.Models;

namespace Web_Store.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Web_Store.Models.Product> Products { get; set; } = default!;
        public DbSet<Web_Store.Models.Cart> Carts { get; set; } = default!;
        public DbSet<Web_Store.Models.CartEntry> CartEntries { get; set; } = default!;
        public DbSet<Web_Store.Models.Order> Order { get; set; } = default!;
        public DbSet<Web_Store.Models.Category> Category { get; set; } = default!;

    }
}