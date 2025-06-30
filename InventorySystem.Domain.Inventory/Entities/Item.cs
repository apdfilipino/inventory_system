using InventorySystem.Domain.Inventory.ValueObjects;
using InventorySystem.Domain.Shared.ValueObjects;

namespace InventorySystem.Domain.Inventory.Entities;

public class Item
{
    public EntityId Id { get; }
    public EntityId TenantId { get; }
    public ItemName Name { get; }
    public string Description { get; }
    public EntityId UnitId { get; }
    
    // Navigation Properties
    public Unit Unit { get; }
    public List<Category> Categories { get; } = new();
    public List<Inventory> Inventories { get; } = new();

    public Item(Guid id, Guid tenantId, string name, string description, Guid unitId)
    {
        Id = EntityId.Create(id);
        TenantId = EntityId.Create(tenantId);
        Name = ItemName.Create(name);
        Description = description;
        UnitId = EntityId.Create(unitId);
    }
    
    public Item() {}
}