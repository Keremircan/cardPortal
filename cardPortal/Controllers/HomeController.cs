using System.Diagnostics;
using cardPortal.Data;
using cardPortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cardPortal.Controllers
{
    [SessionControl]
    public class HomeController : Controller
    {
        private readonly MyAppContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, MyAppContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            int companyid = int.Parse(HttpContext.Session.GetString("CompanyID"));

            int personnelCount = _context.Personnels.Where(p=>p.CompanyId== companyid).Count();
            HttpContext.Session.SetInt32("personnelCount", personnelCount);
            int companyCount = _context.Companies.Count();
            HttpContext.Session.SetInt32("companyCount", companyCount);
            int adminCount = _context.Admins.Count();
            HttpContext.Session.SetInt32("adminCount", adminCount);

            int loginCount = _context.Logins.Count();
            HttpContext.Session.SetInt32("loginCount", loginCount);

            var logins = await _context.Logins.ToListAsync();

            var changes = await _context.Changes.Where(c=>c.CompanyID==companyid).ToListAsync();

            var model = new DashboardViewModel
            {
                Logins = logins,
                Changes = changes
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
