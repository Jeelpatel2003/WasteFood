using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WasteFood.Data;
using WasteFood.Models;
using WasteFood.Models.Entities;
using WasteFood.Models.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace WasteFood.Controllers
{
    public class DonorController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public DonorController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            dbContext = context;
            webHostEnvironment = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DDashboard()
        {
            return View();
        }

        public IActionResult Donor()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
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
                MobileNo = viewModel.MobileNo
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
        [HttpGet]
        public IActionResult AddFood_Donation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFood_Donation(Food_DonationViewModel model, IFormFile FoodImage)
        {
            if (ModelState.IsValid)
            {
                string imagePath = null;

                if (FoodImage != null && FoodImage.Length > 0)
                {
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "uploads");
                    if (!Directory.Exists(uploadsFolder))
                        Directory.CreateDirectory(uploadsFolder);

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(FoodImage.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await FoodImage.CopyToAsync(stream);
                    }

                    imagePath = "/uploads/" + uniqueFileName;
                }

                var donation = new Food_Donation
                {
                    D_Id = model.D_Id,
                    FoodName = model.Food_Name,
                    FoodDescription = model.Food_Description,
                    Quantity = model.Quantity,
                    PickupAddress = model.PickupAddress,
                    ContactNo = model.ContactNumber,
                    Status = model.Status,
                    ImagePath = imagePath
                };

                dbContext.Food_Donation.Add(donation);
                await dbContext.SaveChangesAsync();

                TempData["Success"] = "Food Donation submitted successfully.";
                return RedirectToAction("ListFood_Donation");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ListFood_Donation()
        {
            var donations = await dbContext.Food_Donation.ToListAsync();
            return View(donations);
        }

    }
}
