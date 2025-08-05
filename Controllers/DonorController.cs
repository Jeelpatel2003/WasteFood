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
            ViewBag.DonorCount = dbContext.Donor.Count();
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

        public IActionResult ListFood_Donation()
        {
            var donations = dbContext.Food_Donation.ToList(); // Corrected 'context' to 'dbContext'
            return View(donations); // Ensure a matching view exists
        }

        // Fix for CS0103: The name '_context' does not exist in the current context
        // Replace '_context' with 'dbContext' to use the correct variable name for the database context.

        [HttpPost]
        public async Task<IActionResult> AddFood_Donation(Food_DonationViewModel model, IFormFile FoodImage)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Shows validation errors
            }

            string imagePath = string.Empty; // Initialize with an empty string to avoid null reference warnings

            // 1. Save Image if uploaded
            if (FoodImage != null && FoodImage.Length > 0)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                Directory.CreateDirectory(uploadsFolder); // Ensure folder exists

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(FoodImage.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await FoodImage.CopyToAsync(fileStream);
                }

                imagePath = "/uploads/" + uniqueFileName; // Store relative path for later use
            }

            // 2. Map ViewModel to Entity
            var foodDonation = new Food_Donation
            {
                D_Id = model.D_Id,
                Food_Name = model.Food_Name,
                Food_Description = model.Food_Description,
                Quantity = model.Quantity,
                PickupAddress = model.PickupAddress,
                ContactNo = model.ContactNumber,
                Status = model.Status ?? "Pending", // Optional fallback
                ImagePath = imagePath // No null reference warning as imagePath is initialized
            };

            // 3. Save to DB
            dbContext.Food_Donation.Add(foodDonation); // Corrected '_context' to 'dbContext'
            await dbContext.SaveChangesAsync();

            // 4. Redirect
            return RedirectToAction("ListFood_Donation"); // Or any success page
        }
        [HttpGet]
        public IActionResult EditFood_Donation(int id)
        {
            var donation = dbContext.Food_Donation.FirstOrDefault(d => d.DonationId == id); // Replaced '_context' with 'dbContext'
            if (donation == null) return NotFound();

            var viewModel = new Food_DonationViewModel
            {
                DonationId = donation.DonationId,
                Quantity = donation.Quantity,
                PickupAddress = donation.PickupAddress,
                ContactNo = donation.ContactNo,
                Status = donation.Status,
                ImagePath = donation.ImagePath
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult EditFood_Donation(Food_DonationViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Corrected '_context' to 'dbContext' to use the correct database context variable
            var donation = dbContext.Food_Donation.FirstOrDefault(d => d.DonationId == model.DonationId);
            if (donation == null) return NotFound();

            donation.Quantity = model.Quantity;
            donation.PickupAddress = model.PickupAddress;
            donation.ContactNo = model.ContactNo;
            donation.Status = model.Status;

            if (model.ImageFile != null)
            {
                var fileName = Path.GetFileName(model.ImageFile.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    model.ImageFile.CopyTo(stream);
                }
                donation.ImagePath = fileName;
            }

            dbContext.SaveChanges(); // Corrected '_context' to 'dbContext'
            return RedirectToAction("ListFood_Donation");
        }



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteFoodDonation(int DonationId)
        //{
        //    var donation = dbContext.Food_Donation.Find(DonationId); // Corrected variable name to avoid conflict
        //    if (donation == null)
        //    {
        //        return NotFound();
        //    }

        //    dbContext.Food_Donation.Remove(donation); // Corrected variable name to match the retrieved entity
        //    dbContext.SaveChanges();

        //    TempData["Success"] = "Donation deleted successfully!";
        //    return RedirectToAction("ListFood_Donation");
        //}


        [HttpPost]
        public async Task<IActionResult> DeleteFood_Donation(int DonationId)
        {
            var foodDonation = await dbContext.Food_Donation.FindAsync(DonationId); // Corrected to find the Food_Donation entity
            if (foodDonation != null)
            {
                dbContext.Food_Donation.Remove(foodDonation); // Corrected to remove the Food_Donation entity
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("ListFood_Donation"); // Redirect to the appropriate action
        }

        // Removed the duplicate DDashboard method to resolve CS0111 error.  
        // The duplicate method is unnecessary as the first DDashboard method already exists.  

        // Existing DDashboard method retained:
        

    }
}
