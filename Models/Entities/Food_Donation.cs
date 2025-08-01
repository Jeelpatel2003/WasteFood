using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WasteFood.Models.Entities
{
    public class Food_Donation
    {
        [Key]
        public int FD_Id { get; set; }

        [Required]
        public int D_Id { get; set; }

        [ForeignKey("D_Id")]
        public Donor Donor { get; set; }

        [Required]
        public string FoodName { get; set; }

        [Required]
        public string FoodDescription { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string PickupAddress { get; set; }

        [Required]
        public int ContactNo { get; set; }

        public string Status { get; set; }

        public string ImagePath { get; set; }
    }
}
