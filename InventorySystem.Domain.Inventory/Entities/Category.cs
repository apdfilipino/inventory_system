using InventorySystem.Domain.Inventory.ValueObjects;

namespace InventorySystem.Domain.Inventory.Entities;

public class Category
{
    public CategoryId Id { get; }
    public string Name { get; }
    public string Description { get; }
    public List<Item> Items { get; } = new();

    public Category(Guid id, string name, string description)
    {
        Id = CategoryId.Create(id);
        Name = name;
        Description = description;
    }
    
    public Category() {}
}