using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WasteFood.Data;
using WasteFood.Models.Entities;
using WasteFood.Models.ViewModels; // Assuming your ViewModel is here
using System.Threading.Tasks;

namespace WasteFood.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public UserController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Dashboard (optional)
        public IActionResult CDashboard()
        {
            return View();
        }

        // GET: Customer/Add
        [HttpGet]
        public IActionResult Add()
        {
            return View(new UserViewModel());
        }

        // POST: Customer/Add
        [HttpPost]
        public async Task<IActionResult> Add(UserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                Address = model.Address,
                Password = model.Password
            };

            await _dbContext.User.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(List));
        }

        // GET: Customer/ListCustomer
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var users = await _dbContext.User.ToListAsync();
            return View(users);
        }

        // GET: Customer/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _dbContext.User.FindAsync(id);
            if (user == null)
                return NotFound();

            var model = new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address,
                Password = user.Password
            };
            return View(model);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _dbContext.User.FindAsync(model.Id);
            if (user == null)
                return NotFound();

            user.Name = model.Name;
            user.Email = model.Email;
            user.Phone = model.Phone;
            user.Address = model.Address;
            user.Password = model.Password;

            _dbContext.User.Update(user);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(List));
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _dbContext.User.FindAsync(id);
            if (customer != null)
            {
                _dbContext.User.Remove(customer);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendContact(string name, string email, string message)
        {
            // Here, you can add logic to email or store the message
            TempData["Success"] = "Thank you! We will get back to you shortly.";
            return RedirectToAction("About");
        }
    }
}



