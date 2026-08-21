using eCommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Data;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Ensure the Member Username is unique
        modelBuilder.Entity<Member>()
            .HasIndex(m => m.UserName)
            .IsUnique();
        //Ensure the member Email is unique
        modelBuilder.Entity<Member>()
            .HasIndex(m => m.Email)
            .IsUnique();
    }
    // Entity to be tracked by DbContext
    public DbSet<Product> Products { get; set; }

    public DbSet<Member> Members { get; set; }
}
