using InventorySystem.Domain.Inventory.ValueObjects;
using InventorySystem.Domain.Shared.ValueObjects;

namespace InventorySystem.Domain.Inventory.Entities;

public class Inventory
{
    public InventoryId Id { get; }
    public TenantId TenantId { get; }
    public ItemId ItemId { get; }
    public decimal Price { get; }
    public int Quantity { get; }

    // Navigation Properties
    public Item Item { get; }
    public List<InventoryHistory> History { get; } = new();
    
    public Inventory(Guid id, Guid tenantId, Guid itemId, decimal price, int quantity)
    {
        Id = InventoryId.Create(id);
        TenantId = TenantId.Create(tenantId);
        ItemId = ItemId.Create(itemId);
        Price = price; 
        Quantity = quantity;
    }
    
    public Inventory() { }
}