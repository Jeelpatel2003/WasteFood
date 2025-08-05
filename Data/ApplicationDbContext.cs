using Microsoft.EntityFrameworkCore;
using WasteFood.Models.Entities;
namespace WasteFood.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Donor> Donor { get; set; }
        public DbSet<Food_Donation> Food_Donation { get; set; } // Corrected property name  
        public DbSet<Food_Request> Food_Request { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
