using System.ComponentModel.DataAnnotations;

namespace WasteFood.Models.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }  // For edit

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required, EmailAddress(ErrorMessage = "Valid email required")]
        public string Email { get; set; }

        public int Phone { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
