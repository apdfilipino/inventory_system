using InventorySystem.Domain.Inventory.Entities;
using InventorySystem.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Infrastructure.Data;

public class ApplicationDbContext: DbContext
{
    public DbSet<Item> Items { get; set; }
    public DbSet<Unit> Units { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new ItemConfiguration().Configure(modelBuilder.Entity<Item>());
    }
}