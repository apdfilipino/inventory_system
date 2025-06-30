using InventorySystem.Domain.Inventory.Entities;
using InventorySystem.Domain.Sales.Entities;
using InventorySystem.Domain.Users.Entities;
using InventorySystem.Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySystem.Infrastructure.Configurations;

public class SaleInventoryItemConfiguration: IEntityTypeConfiguration<SaleInventoryItem>
{
    public void Configure(EntityTypeBuilder<SaleInventoryItem> saleInventoryItemBuilder)
    {
        saleInventoryItemBuilder.ToTable("sale_inventory_items");
        
        saleInventoryItemBuilder.HasKey(saleInventory => saleInventory.Id);

        saleInventoryItemBuilder
            .HasOne<Inventory>()
            .WithMany()
            .HasForeignKey(saleInventory => saleInventory.InventoryId);
        
        saleInventoryItemBuilder
            .HasOne<Sale>()
            .WithMany()
            .HasForeignKey(saleInventory => saleInventory.SaleId);
        
        saleInventoryItemBuilder
            .HasOne<Tenant>()
            .WithMany()
            .HasForeignKey(saleInventory => saleInventory.TenantId);
        
        saleInventoryItemBuilder.Property(saleInventoryItem => saleInventoryItem.Id)
            .IsRequired()
            .HasConversion(new EntityIdConverter())
            .HasColumnName("id");
        
        saleInventoryItemBuilder.Property(saleInventoryItem => saleInventoryItem.TenantId)
            .IsRequired()
            .HasConversion(new EntityIdConverter())
            .HasColumnName("tenant_id");
        
        saleInventoryItemBuilder.Property(saleInventoryItem => saleInventoryItem.SaleId)
            .IsRequired()
            .HasConversion(new EntityIdConverter())
            .HasColumnName("sale_id");
        
        saleInventoryItemBuilder.Property(saleInventoryItem => saleInventoryItem.InventoryId)
            .IsRequired()
            .HasConversion(new EntityIdConverter())
            .HasColumnName("inventory_id");
        
        saleInventoryItemBuilder.Property(saleInventoryItem => saleInventoryItem.Quantity)
            .IsRequired()
            .HasColumnName("quantity");
        
        saleInventoryItemBuilder.Property(saleInventoryItem => saleInventoryItem.UnitPrice)
            .IsRequired()
            .HasColumnName("unit_price");
        
        saleInventoryItemBuilder.Property(saleInventoryItem => saleInventoryItem.TotalPrice)
            .IsRequired()
            .HasColumnName("total_price");
    }
}