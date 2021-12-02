using CoreBusiness;
using Microsoft.EntityFrameworkCore;

namespace Plugins.DataStore.SQL;

public class MarketContext : DbContext
{
    public MarketContext(DbContextOptions<MarketContext> options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(c => c.Category)
            .HasForeignKey(c => c.CategoryId);

        // Seeding some data
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Beverage", Description = "Beverage" },
            new Category { CategoryId = 2, Name = "Bakery", Description = "Bakery" },
            new Category { CategoryId = 3, Name = "Meat", Description = "Meat" }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = 1, CategoryId = 1, Name = "Iced Tea", Quantity = 100, Price = 9.99 },
            new Product { ProductId = 2, CategoryId = 2, Name = "Apple Pie", Quantity = 50, Price = 19.99 },
            new Product { ProductId = 3, CategoryId = 3, Name = "Fried Chicken", Quantity = 50, Price = 49.99 }
        );
    }
}
