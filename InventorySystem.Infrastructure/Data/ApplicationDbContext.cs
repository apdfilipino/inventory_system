using InventorySystem.Domain.Inventory.Entities;
using InventorySystem.Domain.Sales.Entities;
using InventorySystem.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Infrastructure.Data;

public class ApplicationDbContext: DbContext
{
    public DbSet<Item> Items { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<InventoryHistory> InventoryHistories { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<Promo> Promos { get; set; }
    public DbSet<PromoItem> PromoItems { get; set; }
    public DbSet<SaleInventoryItem> SaleInventories { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new ItemConfiguration().Configure(modelBuilder.Entity<Item>());
        new UnitConfiguration().Configure(modelBuilder.Entity<Unit>());
        new CategoryConfiguration().Configure(modelBuilder.Entity<Category>());
        new InventoryConfiguration().Configure(modelBuilder.Entity<Inventory>());
        new InventoryHistoryConfiguration().Configure(modelBuilder.Entity<InventoryHistory>());
        new SaleConfiguration().Configure(modelBuilder.Entity<Sale>());
        new PromoConfiguration().Configure(modelBuilder.Entity<Promo>());
        new PromoItemConfiguration().Configure(modelBuilder.Entity<PromoItem>());
        new SaleInventoryItemConfiguration().Configure(modelBuilder.Entity<SaleInventoryItem>());
    }
}