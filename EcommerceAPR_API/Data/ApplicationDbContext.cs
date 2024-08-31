using EcommerceAPR.model;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPR.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }

    }
}
