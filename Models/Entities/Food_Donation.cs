using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WasteFood.Models.Entities
{
    public class FoodDonation  // or Food_Donation if your class name is like that
    {
        [Key]  // <-- This is critical
        public int FD_Id { get; set; }

        public int D_Id { get; set; }  // foreign key

        [ForeignKey("D_Id")]
        public Donor Donor { get; set; }

        [Required]
        public string FoodName { get; set; }

        public string FoodDescription { get; set; }

        public int Quantity { get; set; }

        public string PickupAddress { get; set; }

        public int ContactNo { get; set; }

        public string Status { get; set; }

        public string? ImagePath { get; set; }
    }
}
