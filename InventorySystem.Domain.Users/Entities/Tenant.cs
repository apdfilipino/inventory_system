using InventorySystem.Domain.Shared.ValueObjects;

namespace InventorySystem.Domain.Users.Entities;

public class Tenant
{
    public EntityId Id { get; }
    public string Name { get; }

    // Navigation Properties
    public List<User> Users { get; } = new();
    
    public Tenant(
        Guid id,
        string name)
    {
        Id = EntityId.Create(id);
        Name = name;
    }
}