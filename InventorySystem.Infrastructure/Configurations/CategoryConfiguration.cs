using InventorySystem.Domain.Inventory.Entities;
using InventorySystem.Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySystem.Infrastructure.Configurations;

public class CategoryConfiguration: IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> categoryBuilder)
    {
        categoryBuilder.ToTable("categories");
        
        categoryBuilder.HasKey(category => category.Id);

        categoryBuilder
            .Property(category => category.Id)
            .IsRequired()
            .HasConversion(new CategoryIdConverter())
            .HasColumnName("id");

        categoryBuilder
            .Property(category => category.Name)
            .IsRequired()
            .HasColumnName("name");
        
        categoryBuilder
            .Property(category => category.Description)
            .IsRequired()
            .HasColumnName("description");

    }
}