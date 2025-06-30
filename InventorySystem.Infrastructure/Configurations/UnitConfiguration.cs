using InventorySystem.Domain.Inventory.Entities;
using InventorySystem.Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySystem.Infrastructure.Configurations;

public class UnitConfiguration: IEntityTypeConfiguration<Unit>
{
    public void Configure(EntityTypeBuilder<Unit> unitBuilder)
    {
        unitBuilder.ToTable("units");
        
        unitBuilder.HasKey(unit => unit.Id);

        unitBuilder.Property(unit => unit.Id)
            .IsRequired()
            .HasConversion(new EntityIdConverter())
            .HasColumnName("id");
        
        unitBuilder.Property(unit => unit.Name)
            .IsRequired()
            .HasColumnName("name");
        
    }
}