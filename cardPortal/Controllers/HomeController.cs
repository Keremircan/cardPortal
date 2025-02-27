using System.Diagnostics;
using cardPortal.Data;
using cardPortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Index()
        {
            int personnelCount = _context.Personnels.Count();
            HttpContext.Session.SetInt32("personnelCount", personnelCount);

            return View();
        }
        public IActionResult GetPersonnelCount()
        {
            int? personnelCount = HttpContext.Session.GetInt32("personnelCount") ?? 0;
            return Json(new { count = personnelCount });
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
