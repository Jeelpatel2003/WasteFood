using System.ComponentModel.DataAnnotations;

namespace WasteFood.Models.ViewModels
{
    public class DonorViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Address { get; set; }

        public string MobileNo { get; set; } // ✅ Changed from int to string
    }
}
