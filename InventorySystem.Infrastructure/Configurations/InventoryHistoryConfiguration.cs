using InventorySystem.Domain.Inventory.Entities;
using InventorySystem.Domain.Inventory.Enums;
using InventorySystem.Domain.Sales.Entities;
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
        
        // TODO: Update when Tenant is created
        historyBuilder
            .HasOne(history => history.TenantId)
            .WithMany()
            .HasForeignKey(history => history.TenantId);
        
        // TODO: Update when Sale is created
        historyBuilder
            .HasOne<Sale>()
            .WithMany()
            .HasForeignKey(history => history.SaleId)
            .IsRequired(false);
        
        // TODO: Update when User is created
        // historyBuilder
        //     .HasOne(history =>  history.CreatedBy)
        
        historyBuilder
            .Property(history => history.TenantId)
            .IsRequired()
            .HasColumnName("tenant_id");
        
        historyBuilder
            .Property(history => history.InventoryId)
            .IsRequired()
            .HasColumnName("inventory_id");
        
        historyBuilder
            .Property(history => history.TransactionType)
            .HasConversion<string>()
            .IsRequired()
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
            .Property(history => history.SaleId)
            .IsRequired()
            .HasColumnName("sale_id");
        
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