using cardPortal.Data;
using cardPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cardPortal.Controllers
{
    [SessionControl]
    public class CompanyController : Controller
    {
        private readonly MyAppContext _context;

        public CompanyController(MyAppContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var company = await _context.Companies.OrderByDescending(c=>c.CompanyID).ToListAsync();

            return View(company);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyName, CompanyAddress")] Company company)
        {
            if (ModelState.IsValid)
            {
                var newchange = new Change
                {

                    Name = company.CompanyName,
                    Category = "Company",
                    Action = "Added",
                    ChangeTime = DateTime.Now
                };
                await _context.Changes.AddAsync(newchange);

                company.AddDate = DateTime.Now;
                _context.Companies.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(company);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var company = await _context.Companies.FindAsync(id);

            if (company == null)
            {
                return NotFound(); // Eğer ID bulunamazsa 404 sayfası döner.
            }

            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyName, CompanyAddress")] Company company)
        {
            var currentCom = await _context.Companies.FindAsync(id);

            if (currentCom == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var newchange = new Change
                {

                    Name = company.CompanyName,
                    Category = "Company",
                    Action = "Edited",
                    ChangeTime = DateTime.Now
                };
                await _context.Changes.AddAsync(newchange);

                currentCom.CompanyName = company.CompanyName;
                currentCom.CompanyAddress = company.CompanyAddress;

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(company);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var currentCom = await _context.Companies.FindAsync(id);

            if (currentCom == null)
            {
                return NotFound();
            }

            _context.Companies.Remove(currentCom);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
   
        }
    }
}
