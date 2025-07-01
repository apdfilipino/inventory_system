using InventorySystem.Domain.Inventory.Entities;
using InventorySystem.Domain.Sales.Entities;
using InventorySystem.Domain.Users.Entities;
using InventorySystem.Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySystem.Infrastructure.Configurations;

public class PromoItemConfiguration: IEntityTypeConfiguration<PromoItem>
{
    public void Configure(EntityTypeBuilder<PromoItem> promoItemBuilder)
    {
        promoItemBuilder.ToTable("promo_items");
        promoItemBuilder.HasKey(promoItem => promoItem.Id);

        promoItemBuilder
            .HasOne(promoItem => promoItem.Promo)
            .WithMany(promo => promo.PromoItems)
            .HasForeignKey(promoItem => promoItem.PromoId)
            .OnDelete(DeleteBehavior.Cascade);
        
        promoItemBuilder
            .HasOne<Tenant>()
            .WithMany()
            .HasForeignKey(promoItem => promoItem.TenantId);

        promoItemBuilder
            .HasOne<Item>()
            .WithMany()
            .HasForeignKey(promoItem => promoItem.ItemId);

        promoItemBuilder
            .Property(promoItem => promoItem.Id)
            .IsRequired()
            .HasConversion(new EntityIdConverter())
            .HasColumnName("id");

        promoItemBuilder
            .Property(promoItem => promoItem.ItemId)
            .IsRequired()
            .HasConversion(new EntityIdConverter())
            .HasColumnName("item_id");

        promoItemBuilder
            .Property(promoItem => promoItem.PromoId)
            .IsRequired()
            .HasConversion(new EntityIdConverter())
            .HasColumnName("promo_id");
        
        promoItemBuilder
            .Property(promoItem => promoItem.TenantId)
            .IsRequired()
            .HasConversion(new EntityIdConverter())
            .HasColumnName("tenant_id");
    }
}