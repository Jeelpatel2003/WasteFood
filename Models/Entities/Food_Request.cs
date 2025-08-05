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
        public int User { get; set; }

        public string Name { get; set; }
        public int Mobile_No { get; set; }

        public string Message { get; set; }
        public DateTime Pickup_Date { get; set; }
    }
}
