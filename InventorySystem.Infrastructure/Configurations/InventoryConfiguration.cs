using InventorySystem.Domain.Inventory.Entities;
using InventorySystem.Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySystem.Infrastructure.Configurations;

public class InventoryConfiguration: IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> inventoryBuilder)
    {
        inventoryBuilder.ToTable("inventory");
        
        inventoryBuilder.HasKey(inventory => inventory.Id);
        
        inventoryBuilder
            .HasOne(inventory => inventory.Item)
            .WithMany(item => item.Inventories)
            .HasForeignKey(inventory => inventory.ItemId);
        
        inventoryBuilder
            .Property(inventory => inventory.Id)
            .HasConversion(new EntityIdConverter())
            .IsRequired()
            .HasColumnName("id");
        
        inventoryBuilder
            .Property(inventory => inventory.TenantId)
            .HasConversion(new EntityIdConverter())
            .IsRequired()
            .HasColumnName("tenant_id");
        
        inventoryBuilder
            .Property(inventory => inventory.ItemId)
            .HasConversion(new EntityIdConverter())
            .IsRequired()
            .HasColumnName("item_id");

        inventoryBuilder
            .Property(inventory => inventory.Price)
            .HasDefaultValue(0)
            .HasColumnName("price");
        
        inventoryBuilder
            .Property(inventory => inventory.Quantity)
            .HasDefaultValue(0)
            .HasColumnName("quantity");
    }
}