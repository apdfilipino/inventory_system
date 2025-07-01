using InventorySystem.Domain.Users.Constants;
using InventorySystem.Domain.Users.Entities;
using InventorySystem.Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySystem.Infrastructure.Configurations;

public class TenantConfiguration: IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> tenantBuilder)
    {
        tenantBuilder.ToTable("tenants");
        
        tenantBuilder.HasKey(tenant => tenant.Id);
        
        tenantBuilder.Property(tenant => tenant.Id)
            .IsRequired()
            .HasConversion(new EntityIdConverter())
            .ValueGeneratedOnAdd()
            .HasColumnName("id");

        tenantBuilder.Property(tenant => tenant.Name)
            .IsRequired()
            .HasMaxLength(UserConstants.MaxNameLength)
            .HasColumnName("name");
    }
}