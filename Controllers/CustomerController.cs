using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WasteFood.Data;
using WasteFood.Models.Entities;
using WasteFood.Models.ViewModels; // Assuming your ViewModel is here
using System.Threading.Tasks;

namespace WasteFood.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerController(ApplicationDbContext dbContext)
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
            return View(new CustomerViewModel());
        }

        // POST: Customer/Add
        [HttpPost]
        public async Task<IActionResult> Add(CustomerViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var customer = new Customer
            {
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                Address = model.Address,
                Password = model.Password
            };

            await _dbContext.Customer.AddAsync(customer);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(ListCustomer));
        }

        // GET: Customer/ListCustomer
        [HttpGet]
        public async Task<IActionResult> ListCustomer()
        {
            var customers = await _dbContext.Customer.ToListAsync();
            return View(customers);
        }

        // GET: Customer/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _dbContext.Customer.FindAsync(id);
            if (customer == null)
                return NotFound();

            var model = new CustomerViewModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
                Address = customer.Address,
                Password = customer.Password
            };
            return View(model);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(CustomerViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var customer = await _dbContext.Customer.FindAsync(model.Id);
            if (customer == null)
                return NotFound();

            customer.Name = model.Name;
            customer.Email = model.Email;
            customer.Phone = model.Phone;
            customer.Address = model.Address;
            customer.Password = model.Password;

            _dbContext.Customer.Update(customer);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(ListCustomer));
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _dbContext.Customer.FindAsync(id);
            if (customer != null)
            {
                _dbContext.Customer.Remove(customer);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction(nameof(ListCustomer));
        }
    }
}
