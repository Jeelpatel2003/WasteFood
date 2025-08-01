using System.ComponentModel.DataAnnotations;

namespace WasteFood.Models.ViewModels
{
    public class Food_DonationViewModel
    {
        [Required]
        public int D_Id { get; set; }

        [Required]
        public string Food_Name { get; set; }

        [Required]
        public string Food_Description { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string PickupAddress { get; set; }

        [Required]
        public int ContactNumber { get; set; }

        public string Status { get; set; }
        public string? ExistingImage { get; set; }
    }
}
