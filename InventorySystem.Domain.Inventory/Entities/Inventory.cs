using InventorySystem.Domain.Inventory.ValueObjects;
using InventorySystem.Domain.Shared.ValueObjects;

namespace InventorySystem.Domain.Inventory.Entities;

public class Inventory
{
    public EntityId Id { get; }
    public EntityId TenantId { get; }
    public EntityId ItemId { get; }
    public decimal Price { get; }
    public int Quantity { get; }

    // Navigation Properties
    public Item Item { get; }
    public List<InventoryHistory> History { get; } = new();
    
    public Inventory(Guid id, Guid tenantId, Guid itemId, decimal price, int quantity)
    {
        Id = EntityId.Create(id);
        TenantId = EntityId.Create(tenantId);
        ItemId = EntityId.Create(itemId);
        Price = price; 
        Quantity = quantity;
    }
    
    public Inventory() { }
}