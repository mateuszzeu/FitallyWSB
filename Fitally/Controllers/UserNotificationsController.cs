using Fitally.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fitally.Controllers
{
    public class UserNotificationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserNotificationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Notifications
        public async Task<IActionResult> Index()
        {
            return View(await _context.Notifications.ToListAsync());
        }
    }
}
