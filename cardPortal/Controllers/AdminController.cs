using cardPortal.Data;
using cardPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cardPortal.Controllers
{
    [SessionControl]
    public class AdminController : Controller
    {
        private readonly MyAppContext _context;

        public AdminController(MyAppContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var admin = await _context.Admins.ToListAsync();

            return View(admin);
        }

    }
}
