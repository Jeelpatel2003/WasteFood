using Microsoft.EntityFrameworkCore;
using WasteFood.Models.Entities;
namespace WasteFood.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Customer>Customers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Donor> Donor { get; set; }
        public DbSet<Food_Donation> Food_Donations { get; set; }
        public DbSet<Food_Request> Food_Request { get; set; }

    }
}
