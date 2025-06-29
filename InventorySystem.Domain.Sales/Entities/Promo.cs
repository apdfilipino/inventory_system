using InventorySystem.Domain.Shared.ValueObjects;

namespace InventorySystem.Domain.Sales.Entities;

public class Promo
{
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public TenantId TenantId { get; }
    public Guid CreatedBy { get; }
    public DateTime CreatedAt { get; }
    public DateTime? ExpiresAt { get; }

    public Promo() {}

    public Promo(Guid id, string name, string description, Guid tenantId, Guid createdBy,  DateTime createdAt, DateTime? expiresAt)
    {
        Id = id;
        Name = name;
        Description = description;
        TenantId = TenantId.Create(tenantId);
        CreatedBy = createdBy;
        CreatedAt = createdAt;
        ExpiresAt = expiresAt;
    }
}