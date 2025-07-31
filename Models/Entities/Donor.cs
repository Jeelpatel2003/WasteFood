using System.ComponentModel.DataAnnotations;

namespace WasteFood.Models.Entities
{
    public class Donor
    {
        [Key] // ✅ Required
        public int D_Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Address { get; set; }

        public string MobileNo { get; set; }  // ✅ Change from int to string

    }
}
