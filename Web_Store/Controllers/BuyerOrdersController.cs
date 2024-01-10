using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_Store.Data;
using Web_Store.Models;

namespace Web_Store.Controllers
{
    public class BuyerOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BuyerOrdersController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: BuyerOrders
        public async Task<IActionResult> Index()
        {
            List<Order> userOrders = await _context.Order
                .Where(x => x.BuyerId == _userManager.GetUserId(User))
                .ToListAsync();
            return _context.Order != null ?
                        base.View(userOrders) :
                        base.Problem("Entity set 'ApplicationDbContext.Order'  is null.");
        }

        // GET: BuyerOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

    }
}
