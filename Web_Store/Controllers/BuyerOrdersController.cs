using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
				.Where(buyer => buyer.BuyerId == _userManager.GetUserId(User))
                .Include(x => x.OrderEntries)
                .ToListAsync();

			return _context.Order != null ?
						base.View(userOrders) :
						base.Problem("Entity set 'ApplicationDbContext.Order'  is null.");
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Address")] Order order)
		{
			order.BuyerId = _userManager.GetUserId(User);

			var cart = await _context.Carts
				.Include(x => x.CartEntries)
				.ThenInclude(x => x.Product)
				.SingleOrDefaultAsync(x => x.UserId == _userManager.GetUserId(User));

			order.OrderEntries = new List<OrderEntry>();
			foreach (var entry in cart.CartEntries)
			{
				var orderEntry = new OrderEntry();

				orderEntry.ProductNameAtPurchase = entry.Product.Name;
				orderEntry.UnitPriceAtPurchase = entry.Product.Price;
				orderEntry.Quantity = entry.Quantity;
				orderEntry.ProductId = entry.ProductId;

                order.OrderEntries.Add(orderEntry);
			}

			order.Status = Models.Enums.OrderStatus.PrzyjęteDoRealizacji;

			_context.Add(order);

			cart.CartEntries = new List<CartEntry>();

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));

		}

		// GET: BuyerOrders/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Order == null)
			{
				return NotFound();
			}

			var order = await _context.Order
				.Include(x => x.OrderEntries)
				.FirstOrDefaultAsync(m => m.Id == id);

			if (order == null)
			{
				return NotFound();
			}

			return View(order);
		}

	}
}
