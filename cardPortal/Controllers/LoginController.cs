using Microsoft.AspNetCore.Mvc;
using cardPortal.Models;
using cardPortal.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Http; 

namespace cardPortal.Controllers
{
    public class LoginController : Controller
    {
        private readonly MyAppContext _context;

        public LoginController(MyAppContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([Bind("Username, Password")] Login login)
        {
            if (!ModelState.IsValid)
            {
                return View(login); 
            }

            var admin = await _context.Admins.FirstOrDefaultAsync(a => a.EmailAddress == login.Username);

            if (admin == null)
            {
                ModelState.AddModelError("", "Please check your email!");
                return View(login);
            }else {
                HttpContext.Session.SetString("AdminName", admin.AdminName);
                HttpContext.Session.SetString("CompanyID", admin.CompanyID.ToString());
            }

            if (admin.Password != login.Password)
            {
                ModelState.AddModelError("", "Please check your password!");
                return View(login);
            }
            
            HttpContext.Session.SetString("Username", login.Username);

            var prevlogin = await _context.Logins.Where(l => l.Username == login.Username).ToListAsync();
            if (prevlogin != null)
            {
                foreach (var log in prevlogin)
                {
                    _context.Logins.Remove(log);   
                }
                await _context.SaveChangesAsync();
            }


            login.LoginDate = DateTime.Now;
            _context.Logins.Add(login);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            var username = HttpContext.Session.GetString("Username");
            var currentuser = await _context.Logins.FirstOrDefaultAsync(l => l.Username == username);

            if (currentuser != null)
            {
                _context.Logins.Remove(currentuser);
                await _context.SaveChangesAsync();
            }

            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Login");
        }
    }
}
