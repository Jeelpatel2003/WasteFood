using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace WasteFood.Models.ViewModels
{
    public class Food_DonationViewModel
    {
        public int? Fd_ID { get; set; }  // nullable, for create vs edit scenarios

        [Required(ErrorMessage = "Donor is required")]
        public int D_Id { get; set; }

        [Required(ErrorMessage = "Food name is required")]
        [StringLength(100, ErrorMessage = "Food name can't be longer than 100 characters")]
        public string Food_Name { get; set; } 

        [StringLength(500, ErrorMessage = "Description can't be longer than 500 characters")]
        public string? Food_Description { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Pickup address is required")]
        [StringLength(200)]
        public string PickupAddress { get; set; } 

        [Required(ErrorMessage = "Contact number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public int ContactNumber { get; set; } 

        public string? Status { get; set; }

        //For image upload from form
        [Display(Name = "Upload Image")]
        public IFormFile? ImageFile { get; set; }

        // To hold existing image path/name when editing
        public string? ExistingImage { get; set; }
    }
}
