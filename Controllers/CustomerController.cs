using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WasteFood.Data;
using WasteFood.Models;
using WasteFood.Models.Entities;

namespace WasteFood.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public CustomerController (ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult CDashboard()
        {
            return View();
        }

        
        public IActionResult AddCustomer(AddCustomerView viewModel)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddCustomerView viewModel)
        {
            var Customer = new Customer
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Address = viewModel.Address,
                Password = viewModel.Password
            };
            await dbContext.Customers.AddAsync(Customer);
            await dbContext.SaveChangesAsync();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ListCustomer()
        {
            var Customer = await dbContext.Customers.ToListAsync();

            return View(Customer);
        }
    }
}
