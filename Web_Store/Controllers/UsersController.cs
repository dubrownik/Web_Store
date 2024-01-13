using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Web_Store.Data;
using Web_Store.Models;

namespace Web_Store.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            List<ApplicationUser> users = await _context.Users
                //.Include(x => x.)
                .ToListAsync();

            return _context.Users != null ?
                        base.View(users) :
                        base.Problem("Entity set 'ApplicationDbContext.Users'  is null.");
        }

        // POST: /Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var currentUserId = _userManager.GetUserId(User);

                if (id == null || id == currentUserId)
                {
                    return RedirectToAction(nameof(Index));
                }

                var user = await _userManager.FindByIdAsync(id);
                var roles = await _userManager.GetRolesAsync(user);

                var result = await _userManager.RemoveFromRolesAsync(user, roles);
                if (result.Succeeded)
                {
                    var resultdelete = await _userManager.DeleteAsync(user);
                }

                //var user = await _userManager.FindByIdAsync(id);
                //var logins = user.Logins;
                //var rolesForUser = await _userManager.GetRolesAsync(id);

                //using (var transaction = context.Database.BeginTransaction())
                //{
                //    foreach (var login in logins.ToList())
                //    {
                //        await _userManager.RemoveLoginAsync(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
                //    }

                //    if (rolesForUser.Count() > 0)
                //    {
                //        foreach (var item in rolesForUser.ToList())
                //        {
                //            // item should be the name of the role
                //            var result = await _userManager.RemoveFromRoleAsync(user.Id, item);
                //        }
                //    }

                //    await _userManager.DeleteAsync(user);
                //    transaction.Commit();
                //}
            }
            catch
            {
                return RedirectToAction(nameof(HomeController.Error));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
