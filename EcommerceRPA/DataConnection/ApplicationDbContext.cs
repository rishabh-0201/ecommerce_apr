using EcommerceAPR.model;
using EcommerceRPA.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceRPA.DataConnection
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<State> States { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

      

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Feature> Features { get; set; }


        public DbSet<Color> Colors { get; set; }

        public DbSet<RAM> RAMs { get; set; }

        public DbSet<ROM> ROMs { get; set; }


        public DbSet<Processor> Processors { get; set; }

    }
}
