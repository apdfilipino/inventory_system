using InventorySystem.Domain.Shared.ValueObjects;

namespace InventorySystem.Domain.Inventory.Entities;

public class Unit
{
    public EntityId Id { get; }
    public string Name { get; }

    public Unit(Guid id, string name)
    {
        Id = EntityId.Create(id);
        Name = name;
    }
    
    public Unit() {}
}