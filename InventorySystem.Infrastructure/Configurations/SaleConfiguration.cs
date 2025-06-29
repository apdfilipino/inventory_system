using InventorySystem.Domain.Sales.Entities;
using InventorySystem.Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySystem.Infrastructure.Configurations;

public class SaleConfiguration: IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> saleBuilder)
    {
        saleBuilder.HasKey(sale => sale.Id);
        
        // TODO when Tenant is Available
        // saleBuilder
        //     .HasOne<Tenant>()
        //     .WithMany()
        //     .HasForeignKey(sale => sale.TenantId);
        
        // TODO when User is Available
        // saleBuilder
        //     .HasOne<User>()
        //     .WithMany()
        //     .HasForeignKey(sale => sale.CreatedBy);
        
        saleBuilder
            .Property(sale => sale.Id)
            .IsRequired()
            .HasConversion(new SaleIdConverter())
            .HasColumnName("id");
        
        saleBuilder
            .Property(sale => sale.TenantId)
            .IsRequired()
            .HasColumnName("tenant_id");
        
        saleBuilder
            .Property(sale => sale.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");
        
        saleBuilder
            .Property(sale => sale.CreatedBy)
            .IsRequired()
            .HasColumnName("created_by");
        
        saleBuilder
            .Property(sale => sale.TotalAmount)
            .IsRequired()
            .HasColumnName("total_amount");
        
        saleBuilder
            .Property(sale => sale.EffectiveTotalAmount)
            .IsRequired()
            .HasColumnName("effective_total_amount");
        
        saleBuilder
            .Property(sale => sale.PromoApplied)
            .IsRequired()
            .HasColumnName("promo_applied");
    }
}