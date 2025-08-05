using Microsoft.AspNetCore.Http;

namespace WasteFood.Models.ViewModels
{
    public class Food_DonationViewModel
    {
        public int DonationId { get; set; }
        public int D_Id { get; set; }

        // ✅ ADD THESE MISSING PROPERTIES
        public string Food_Name { get; set; }
        public string Food_Description { get; set; }
        public string ContactNumber { get; set; }

        public int Quantity { get; set; }
        public string PickupAddress { get; set; }
        public string Status { get; set; }

        public IFormFile ImageFile { get; set; }
        public string ImagePath { get; set; }
    }
}
