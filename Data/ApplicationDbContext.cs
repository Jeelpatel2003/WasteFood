using Microsoft.EntityFrameworkCore;
using WasteFood.Models.Entities;
namespace WasteFood.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Donor> Donor { get; set; }
        public DbSet<FoodDonation> Food_Donation { get; set; }
      

    }
}
