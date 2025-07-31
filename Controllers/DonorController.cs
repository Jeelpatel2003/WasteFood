using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WasteFood.Data;
using WasteFood.Models;
using WasteFood.Models.Entities;
using System;
using System.Threading.Tasks;
using WasteFood.Models.ViewModels;

namespace WasteFood.Controllers
{
    public class DonorController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        // ✅ Corrected constructor assignment
        public DonorController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult DDashboard()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(DonorViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var donor = new Donor
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Password = viewModel.Password,
                Address = viewModel.Address,
                MobileNo = viewModel.Phone
            };

            await dbContext.Donor.AddAsync(donor);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var donorList = await dbContext.Donor.ToListAsync();
            return View(donorList);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var donor = await dbContext.Donor.FindAsync(id);
            if (donor == null)
            {
                return NotFound();
            }

            return View(donor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Donor model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var donor = await dbContext.Donor.FindAsync(model.D_Id);
            if (donor == null)
            {
                return NotFound();
            }

            donor.Name = model.Name;
            donor.Email = model.Email;
            donor.Password = model.Password;
            donor.Address = model.Address;
            donor.MobileNo = model.MobileNo;

            dbContext.Donor.Update(donor);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var donor = await dbContext.Donor.FindAsync(id);
            if (donor != null)
            {
                dbContext.Donor.Remove(donor);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List");
        }

        public IActionResult Food_Request()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Food_Request(Food_DonationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var request = new FoodDonation
                {
                    FoodName = model.Food_Name,
                    FoodDescription = model.Food_Description,
                    Quantity = model.Quantity,
                    PickupAddress = model.PickupAddress,
                    ContactNo = model.ContactNumber,
                    Status = model.Status,
                    ImagePath = model.ExistingImage
                };

                dbContext.Food_Donation.Add(request);
                dbContext.SaveChanges();

                TempData["Success"] = "Food request submitted successfully.";
                return RedirectToAction("Food_Request");
            }

            return View(model);
        }
    }
}
