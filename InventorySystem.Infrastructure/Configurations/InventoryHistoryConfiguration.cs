using InventorySystem.Domain.Inventory.Entities;
using InventorySystem.Domain.Inventory.Enums;
using InventorySystem.Domain.Sales.Entities;
using InventorySystem.Domain.Users.Entities;
using InventorySystem.Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InventorySystem.Infrastructure.Configurations;

public class InventoryHistoryConfiguration: IEntityTypeConfiguration<InventoryHistory>
{
    public void Configure(EntityTypeBuilder<InventoryHistory> historyBuilder)
    {
        historyBuilder.ToTable("inventory_history");
        historyBuilder.HasKey(history => history.Id);

        historyBuilder
            .HasOne(history => history.Inventory)
            .WithMany(inventory => inventory.History)
            .HasForeignKey(history => history.InventoryId);
        
        historyBuilder
            .HasOne<Tenant>()
            .WithMany()
            .HasForeignKey(history => history.TenantId);
        
        historyBuilder
            .HasOne<Sale>()
            .WithMany()
            .HasForeignKey(history => history.SaleId)
            .IsRequired(false);
        
        historyBuilder
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(history => history.CreatedBy);
        
        historyBuilder
            .Property(history => history.InventoryId)
            .IsRequired()
            .HasConversion(new EntityIdConverter())
            .HasColumnName("inventory_id");
        
        historyBuilder
            .Property(history => history.TenantId)
            .IsRequired()
            .HasConversion(new EntityIdConverter())
            .HasColumnName("tenant_id");
        
        historyBuilder
            .Property(history => history.SaleId)
            .HasConversion(new EntityIdConverter())
            .HasColumnName("sale_id");
        
        historyBuilder
            .Property(history => history.TransactionType)
            .IsRequired()
            .HasConversion<string>()
            .HasColumnName("transaction_type");
        
        historyBuilder
            .Property(history => history.ChangeQuantity)
            .IsRequired()
            .HasColumnName("change_quantity");
        
        historyBuilder
            .Property(history => history.ChangeReference)
            .IsRequired()
            .HasColumnName("change_reference");
        
        historyBuilder
            .Property(history => history.Price)
            .IsRequired()
            .HasColumnName("price");
        
        historyBuilder
            .Property(history => history.CreatedBy)
            .IsRequired()
            .HasColumnName("created_by");
        
        historyBuilder
            .Property(history => history.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");
    }
}