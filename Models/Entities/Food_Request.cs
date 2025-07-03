using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WasteFood.Models.Entities
{
    public class Food_Request
    {
        [Key]   
        public int Fr_Id { get; set; }
        public int Id { get; set; } // ForeignKey
        [ForeignKey("Id")]
        public Customer Customers { get; set; }
        public string Food_Details { get; set; }    
        public string Description { get; set; } 
    }
}
