using System.ComponentModel.DataAnnotations;

namespace WasteFood.Models.Entities
{
    public class Donor
    {
        [Key]
        public int D_Id { get; set; } //primary key
        public string Name { get; set; }
        public string Email { get; set; }
        public int Password { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
    }
}
