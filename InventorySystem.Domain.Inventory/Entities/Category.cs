using InventorySystem.Domain.Inventory.ValueObjects;
using InventorySystem.Domain.Shared.ValueObjects;

namespace InventorySystem.Domain.Inventory.Entities;

public class Category
{
    public EntityId Id { get; }
    public string Name { get; }
    public string Description { get; }
    public List<Item> Items { get; } = new();

    public Category(Guid id, string name, string description)
    {
        Id = EntityId.Create(id);
        Name = name;
        Description = description;
    }
    
    public Category() {}
}