using InventorySystem.Domain.Inventory.ValueObjects;
using InventorySystem.Domain.Shared.ValueObjects;

namespace InventorySystem.Domain.Inventory.Entities;

public class Item
{
    public ItemId Id { get; }
    public TenantId TenantId { get; }
    public ItemName Name { get; }
    public string Description { get; }
    public UnitId UnitId { get; }
    
    public Item(Guid id, Guid tenantId, string name, string description, Guid unitId)
    {
        Id = ItemId.Create(id);
        TenantId = TenantId.Create(tenantId);
        Name = ItemName.Create(name);
        Description = description;
        UnitId = UnitId.Create(unitId);
    }
}