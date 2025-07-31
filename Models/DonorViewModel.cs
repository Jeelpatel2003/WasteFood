using System.ComponentModel.DataAnnotations;

namespace WasteFood.Models
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
        [Required]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public int Phone { get; set; }
    }
}
