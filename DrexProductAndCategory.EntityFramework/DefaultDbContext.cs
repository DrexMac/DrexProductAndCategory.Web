using DrexProductAndCategory.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DrexProductAndCategory.EntityFramework
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Guid categoryId1 = Guid.NewGuid();
            Guid categoryId2 = Guid.NewGuid();

            List<Category> categories = new List<Category>()
            {
                new Category()
                {
                    Id = categoryId1,
                    Name = "Electronics",
                    Description = "Electronic gadgets and devices"
                },
                new Category()
                {
                    Id = categoryId2,
                    Name = "Clothing",
                    Description = "Fashionable wearables"
                }
            };

            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone",
                    Price = 699.99m,
                    Stock = 50,
                    CategoryId = categoryId1
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Jeans",
                    Price = 49.99m,
                    Stock = 100,
                    CategoryId = categoryId2
                }
            };

            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Product>().HasData(products);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
