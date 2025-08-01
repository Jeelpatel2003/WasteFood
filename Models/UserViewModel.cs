using System.ComponentModel.DataAnnotations;

namespace WasteFood.Models.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required, EmailAddress(ErrorMessage = "Valid email required")]
        public string Email { get; set; }

        public string Phone { get; set; }  // ✅ Changed to string (no validation)

        public string Address { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
