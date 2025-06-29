using InventorySystem.Domain.Inventory.Enums;
using InventorySystem.Domain.Inventory.ValueObjects;
using InventorySystem.Domain.Shared.ValueObjects;

namespace InventorySystem.Domain.Inventory.Entities;

public class InventoryHistory
{
    public Guid Id { get; } // TODO: Turn into ValueObject
    public TenantId TenantId { get; }
    public InventoryId InventoryId { get; }
    public InventoryTransactionType TransactionType { get; }
    public int ChangeQuantity { get; }
    public string ChangeReference { get; }
    public decimal Price { get; }
    public Guid? SaleId { get; } // TODO: Update when Sale Entity is Created
    public Guid CreatedBy { get; } // TODO: Update when User Entity is Created
    public DateTime CreatedAt { get; }

    // Navigation Properties
    public Inventory Inventory { get; }
    
    public InventoryHistory(
        Guid id,
        Guid tenantId,
        Guid inventoryId,
        InventoryTransactionType transactionType,
        decimal price,
        int quantity,
        string changeReference,
        Guid? saleId,
        Guid createdBy,
        DateTime createdAt)
    {
        Id = id;
        TenantId = TenantId.Create(tenantId);
        InventoryId = InventoryId.Create(inventoryId);
        TransactionType = transactionType;
        ChangeQuantity = quantity;
        ChangeReference = changeReference;
        SaleId = saleId;
        Price = price;
        CreatedBy = createdBy;
        CreatedAt = createdAt;
    }
    
    public InventoryHistory() {}
}