using InventorySystem.Domain.Inventory.Entities;
using InventorySystem.Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySystem.Infrastructure.Configurations;

public class ItemConfiguration: IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> itemBuilder)
    {
        itemBuilder.ToTable("items");
        
        itemBuilder.HasKey(item => item.Id);
        
        itemBuilder.HasOne<Unit>()
            .WithMany()
            .HasForeignKey(item => item.UnitId)
            .OnDelete(DeleteBehavior.Restrict);
        
        itemBuilder.Property(item => item.TenantId)
            .IsRequired()
            .HasConversion(new TenantIdConverter())
            .HasColumnName("tenant_id");
        
        itemBuilder.Property(item => item.Name)
            .IsRequired()
            .HasConversion(new ItemNameConverter())
            .HasColumnName("name");
        
        itemBuilder.Property(item => item.Id)
            .IsRequired()
            .HasConversion(new ItemIdConverter())
            .HasColumnName("id");
        
        itemBuilder.Property(item => item.UnitId)
            .IsRequired()
            .HasConversion(new UnitIdConverter())
            .HasColumnName("unit_id");
    }
}