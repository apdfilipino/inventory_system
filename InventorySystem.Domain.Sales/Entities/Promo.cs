using InventorySystem.Domain.Shared.ValueObjects;

namespace InventorySystem.Domain.Sales.Entities;

public class Promo
{
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public EntityId TenantId { get; }
    public EntityId CreatedBy { get; }
    public DateTime CreatedAt { get; }
    public DateTime? ExpiresAt { get; }
    
    // Navigation Properties
    public List<PromoItem> PromoItems { get; } = new();
    public List<Sale> Sales { get; } = new();
    
    public Promo() {}

    public Promo(Guid id,
        string name,
        string description,
        Guid tenantId,
        Guid createdBy,
        DateTime createdAt,
        DateTime? expiresAt)
    {
        Id = id;
        Name = name;
        Description = description;
        TenantId = EntityId.Create(tenantId);
        CreatedBy = EntityId.Create(createdBy);
        CreatedAt = createdAt;
        ExpiresAt = expiresAt;
    }
}