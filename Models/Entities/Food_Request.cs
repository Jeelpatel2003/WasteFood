using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WasteFood.Models.Entities
{
    public class Food_Request
    {
        [Key]
        public int Fr_ID { get; set; }

        [Required]
        public int Id { get; set; }

        [ForeignKey("Id")]
        public User Customer { get; set; }

        public string Food_Name { get; set; }

        public string Food_Description { get; set; }
        public DateTime Pickup_Date { get; set; }
    }
}
