using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cardPortal.Data;
using cardPortal.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace cardPortal.Controllers
{
    [SessionControl]
    public class PersonnelController : Controller
    {
        private readonly MyAppContext _context;
        public PersonnelController(MyAppContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var adminCompID = int.Parse(HttpContext.Session.GetString("CompanyID"));
            var personnel = await _context.Personnels.Where(p=>p.CompanyId == adminCompID).ToListAsync();
            return View(personnel);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CardNo,RollId,FullName,Company,PhoneNumber,MobileNumber,PhoneNumber2,EmailAddress,Password,JobTitle,WorkAddress,Image")] Personnel personnel)
        {
            if (ModelState.IsValid)
            {
                var newchange = new Change
                {

                    Name = personnel.FullName,
                    Category = "Personnel",
                    Action = "Added",
                    ChangeTime = DateTime.Now
                };
                await _context.Changes.AddAsync(newchange);

                personnel.AddDate = DateTime.Now;
                personnel.UpdDate = null;
                personnel.CompanyId = int.Parse(HttpContext.Session.GetString("CompanyID"));
                _context.Personnels.Add(personnel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(personnel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var personnel = await _context.Personnels.FindAsync(id);

            if (personnel == null)
            {
                return NotFound();
            }
            return View(personnel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CardNo,RollId,FullName,Company,PhoneNumber,MobileNumber,PhoneNumber2,EmailAddress,Password,JobTitle,WorkAddress,Image")] Personnel personnel)
        {
            var currentPer = await _context.Personnels.FindAsync(id);
            if (currentPer == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var newchange = new Change
                {

                    Name = personnel.FullName,
                    Category = "Personnel",
                    Action = "Edited",
                    ChangeTime = DateTime.Now
                };
                await _context.Changes.AddAsync(newchange);

                currentPer.UpdDate= DateTime.Now;
                currentPer.CardNo = personnel.CardNo;
                currentPer.RollId = personnel.RollId;
                currentPer.FullName = personnel.FullName;
                currentPer.Company = personnel.Company; 
                currentPer.PhoneNumber = personnel.PhoneNumber;
                currentPer.MobileNumber = personnel.MobileNumber;
                currentPer.PhoneNumber2 = personnel.PhoneNumber2;
                currentPer.EmailAddress = personnel.EmailAddress;
                currentPer.Password = personnel.Password;
                currentPer.JobTitle = personnel.JobTitle;
                currentPer.WorkAddress = personnel.WorkAddress;
                currentPer.Image = personnel.Image;

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(personnel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var currentPer = await _context.Personnels.FindAsync(id);

            if (currentPer == null)
            {
                return NotFound();
            }

            var newchange = new Change
            {

                Name = currentPer.FullName,
                Category = "Personnel",
                Action = "Deleted",
                ChangeTime = DateTime.Now
            };
            await _context.Changes.AddAsync(newchange);

            _context.Personnels.Remove(currentPer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
