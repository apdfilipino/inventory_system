using InventorySystem.Domain.Shared.ValueObjects;

namespace InventorySystem.Domain.Inventory.Entities;

public class Unit
{
    public UnitId Id { get; }
    public string Name { get; }

    public Unit(Guid id, string name)
    {
        Id = UnitId.Create(id);
        Name = name;
    }
}