using InventorySystem.Domain.Users.Constants;
using InventorySystem.Domain.Users.Entities;
using InventorySystem.Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySystem.Infrastructure.Configurations;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> userBuilder)
    {
        userBuilder.ToTable("users");
        
        userBuilder.HasKey(user => user.Id);
        
        userBuilder
            .HasOne(user => user.Tenant)
            .WithMany(tenant => tenant.Users)
            .HasForeignKey(user => user.TenantId);
        
        userBuilder
            .Property(user => user.Id)
            .IsRequired()
            .HasConversion(new EntityIdConverter())
            .HasColumnName("id");
        
        userBuilder
            .Property(user => user.TenantId)
            .IsRequired()
            .HasConversion(new EntityIdConverter())
            .HasColumnName("tenant_id");
        
        userBuilder.OwnsOne(user => user.Name)
            .Property(name => name.FirstName)
            .HasMaxLength(UserConstants.MaxNameLength)
            .HasColumnName("first_name");
        
        userBuilder.OwnsOne(user => user.Name)
            .Property(name => name.LastName)
            .IsRequired()
            .HasMaxLength(UserConstants.MaxNameLength)
            .HasColumnName("last_name");
        
        userBuilder.OwnsOne(user => user.Email)
            .Property(email => email.Email)
            .IsRequired()
            .HasMaxLength(UserConstants.MaxEmailLength)
            .HasColumnName("email");
    }
}