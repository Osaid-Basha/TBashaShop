using Microsoft.EntityFrameworkCore;
using TBashaShop.Models;

namespace TBashaShop.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companys { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=TBashaShop;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(

                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Clothing" },
                new Category { Id = 3, Name = "Books" },
                new Category { Id = 4, Name = "Home Appliances" },
                new Category { Id = 5, Name = "Sports" },
                new Category { Id = 6, Name = "Toys" },
                new Category { Id = 7, Name = "Beauty Products" },
                new Category { Id = 8, Name = "Automotive" }
                );
        }
    }
}
