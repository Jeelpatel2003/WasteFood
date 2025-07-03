using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WasteFood.Models.Entities
{
    public class Food_Donation
    {
        [Key]
        public int Fd_ID { get; set; }
        public int D_Id { get; set; } // ForeignKey
        [ForeignKey("D_Id")]
        public Donor Donor { get; set; }
        public string Food_Name { get; set; }
        public string Food_Description { get; set; }    
        public string Quantity { get; set; }    
        public string Status { get; set; }

    }
}
