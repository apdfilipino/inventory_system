using InventorySystem.Domain.Shared.ValueObjects;

namespace InventorySystem.Domain.Sales.Entities;

public class SaleInventoryItem
{
    public EntityId Id { get; }
    public EntityId InventoryId { get; }
    public EntityId SaleId { get; }
    public EntityId TenantId { get; }
    public int Quantity { get; }
    public decimal UnitPrice { get; }
    public decimal TotalPrice { get; }

    // Navigation Properties
    public Sale Sale { get; }

    public SaleInventoryItem(
        Guid id,
        Guid inventoryId,
        Guid saleId,
        Guid tenantId,
        int quantity,
        decimal unitPrice,
        decimal totalPrice
        )
    {
        Id = EntityId.Create(id);
        InventoryId = EntityId.Create(inventoryId);
        SaleId = EntityId.Create(saleId);
        TenantId = EntityId.Create(tenantId);
        Quantity = quantity;
        UnitPrice = unitPrice;
        TotalPrice = totalPrice;
    }
    
    public SaleInventoryItem() { }
}