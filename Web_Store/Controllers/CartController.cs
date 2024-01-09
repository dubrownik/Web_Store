using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_Store.Data;
using Web_Store.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Web_Store.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Get(/GetCartEntries/Index)
        // AddEntry
        // EditEntry
        // DeleteEntry

        // GET: Cart
        public async Task<IActionResult> Index()
        {
            var cart = await _context.Carts
                .Include(x => x.CartEntries)
                .ThenInclude(x => x.Product)
                .SingleOrDefaultAsync(x => x.UserId == _userManager.GetUserId(User));

            return cart is not null ?
                View(cart) :
                Problem("Couldn't find user's cart");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEntry(CartEntry entry)
        {
            var cart = await _context.Carts.SingleOrDefaultAsync(x => x.UserId == _userManager.GetUserId(User));
            entry.CartId = cart.Id;

            _context.Add(entry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        // Edit entry

        // POST: Cart/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEntry(int id)
        {
            if (_context.Carts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cart'  is null.");
            }
            var cart = await _context.CartEntries.FindAsync(id);
            if (cart != null)
            {
                _context.CartEntries.Remove(cart);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
