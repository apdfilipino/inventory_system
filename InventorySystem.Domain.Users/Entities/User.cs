using InventorySystem.Domain.Shared.ValueObjects;
using InventorySystem.Domain.Users.ValueObjects;

namespace InventorySystem.Domain.Users.Entities;

public class User
{
    public EntityId Id { get; }
    public UserName Name { get; }
    public UserEmail Email { get; }
    public EntityId TenantId { get; }

    // Navigation Properties
    public Tenant Tenant { get; }

    public User CreateNewUser(string firstName, string lastName, string email, Tenant tenant)
    {
        var userName = UserName.FromFirstAndLastName(firstName, lastName);
        var userEmail = UserEmail.FromString(email);
        return new User(Guid.NewGuid(), userName, userEmail, tenant.Id.Value);
    }
    
    public User(
        Guid id,
        UserName name,
        UserEmail email,
        Guid tenantId
        )
    {
        Id = EntityId.Create(id);
        Name = name;
        Email = email;
        TenantId = EntityId.Create(tenantId);
    }
    
    public User()
    {
        
    }
    
}