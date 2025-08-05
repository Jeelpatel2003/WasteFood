using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WasteFood.Models.Entities
{
    public class Food_Donation
    {
        [Key] // ✅ Primary Key
        public int DonationId { get; set; }

        [ForeignKey("Donor")] // ✅ Foreign Key to Donor table
        public int D_Id { get; set; }

        public string Food_Name { get; set; }

        public string Food_Description { get; set; }

        public int Quantity { get; set; }

        public string PickupAddress { get; set; }

        public string ContactNo { get; set; }

        public string Status { get; set; }

        public string ImagePath { get; set; }

        // ✅ Navigation Property
        public Donor Donor { get; set; }
    }
}
