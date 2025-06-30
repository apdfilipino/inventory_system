using InventorySystem.Domain.Inventory.Enums;
using InventorySystem.Domain.Inventory.ValueObjects;
using InventorySystem.Domain.Shared.ValueObjects;

namespace InventorySystem.Domain.Inventory.Entities;

public class InventoryHistory
{
    public EntityId Id { get; }
    public EntityId TenantId { get; }
    public EntityId InventoryId { get; }
    public InventoryTransactionType TransactionType { get; }
    public int ChangeQuantity { get; }
    public string ChangeReference { get; }
    public decimal Price { get; }
    public EntityId? SaleId { get; }
    public EntityId CreatedBy { get; }
    public DateTime CreatedAt { get; }

    // Navigation Properties
    public Inventory Inventory { get; }
    
    public InventoryHistory(
        Guid id,
        Guid tenantId,
        Guid inventoryId,
        InventoryTransactionType transactionType,
        decimal price,
        int changeQuantity,
        string changeReference,
        Guid? saleId,
        Guid createdBy,
        DateTime createdAt)
    {
        Id = EntityId.Create(id);
        TenantId = EntityId.Create(tenantId);
        InventoryId = EntityId.Create(inventoryId);
        TransactionType = transactionType;
        ChangeQuantity = changeQuantity;
        ChangeReference = changeReference;
        SaleId = EntityId.Create(saleId);
        Price = price;
        CreatedBy = EntityId.Create(createdBy);
        CreatedAt = createdAt;
    }
    
    public InventoryHistory() {}
}