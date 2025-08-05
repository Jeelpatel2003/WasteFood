using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WasteFood.Data; // Your EF DbContext
using System.Linq;

namespace WasteFood.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Admin/Login (DB-based login)
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var admin = _context.Admin
                .FirstOrDefault(a => a.Username == username && a.Password == password);

            if (admin != null)
            {
                HttpContext.Session.SetString("AdminUser", username);
                return RedirectToAction("Dashboard");
            }

            TempData["Error"] = "Invalid username or password.";
            return View();
        }

        // GET: Admin/Dashboard (requires login)
        public IActionResult Dashboard()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("AdminUser")))
                return RedirectToAction("Login");

            ViewBag.DonorCount = _context.Donor.Count();
            ViewBag.UserCount = _context.User.Count();
            ViewBag.Food_DonationCount = _context.Food_Donation.Count();

            return View();
        }

        // GET: Admin/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
