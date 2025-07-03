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
    }
}
