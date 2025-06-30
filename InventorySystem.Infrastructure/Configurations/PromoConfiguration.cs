using InventorySystem.Domain.Inventory.Entities;
using InventorySystem.Domain.Sales.Entities;
using InventorySystem.Domain.Users.Entities;
using InventorySystem.Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySystem.Infrastructure.Configurations;

public class PromoConfiguration: IEntityTypeConfiguration<Promo>
{
    public void Configure(EntityTypeBuilder<Promo> promoBuilder)
    {
        promoBuilder.ToTable("promos");
        
        promoBuilder.HasKey(promo => promo.Id);
        
        promoBuilder
            .HasOne<Tenant>()
            .WithMany()
            .HasForeignKey(promo => promo.TenantId);
        
        
        promoBuilder
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(promo => promo.CreatedBy);
        
        promoBuilder.Property(promo => promo.Id)
            .IsRequired()
            .ValueGeneratedOnAdd()
            .HasConversion(new EntityIdConverter())
            .HasColumnName("id");

        promoBuilder.Property(promo => promo.Name)
            .IsRequired()
            .HasColumnName("name");
        
        promoBuilder.Property(promo => promo.Description)
            .IsRequired()
            .HasColumnName("description");
        
        promoBuilder.Property(promo => promo.TenantId)
            .IsRequired()
            .HasConversion(new EntityIdConverter())
            .HasColumnName("tenant_id");
        
        promoBuilder.Property(promo => promo.CreatedBy)
            .IsRequired()
            .HasConversion(new EntityIdConverter())
            .HasColumnName("created_by");
        
        promoBuilder.Property(promo => promo.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");
        
        promoBuilder.Property(promo => promo.ExpiresAt)
            .HasDefaultValueSql(null)
            .HasColumnName("expires_at");
    }
}