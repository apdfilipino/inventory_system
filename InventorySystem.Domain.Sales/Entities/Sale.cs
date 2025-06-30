using InventorySystem.Domain.Shared.ValueObjects;

namespace InventorySystem.Domain.Sales.Entities;

public class Sale
{
    public EntityId Id { get; }
    public EntityId TenantId { get; }
    public DateTime CreatedAt { get; }
    public EntityId CreatedBy { get; }
    public decimal TotalAmount { get; }
    public decimal EffectiveTotalAmount { get; }
    public bool PromoApplied { get; }
    
    // Navigation Property
    public List<Promo> Promos { get; } = new();

    public Sale(Guid id,
        Guid tenantId,
        DateTime createdAt,
        Guid createdBy,
        decimal totalAmount,
        decimal effectiveTotalAmount,
        bool promoApplied)
    {
        Id = EntityId.Create(id);
        TenantId = EntityId.Create(tenantId);
        CreatedAt = createdAt;
        CreatedBy = EntityId.Create(createdBy);
        TotalAmount = totalAmount;
        EffectiveTotalAmount = effectiveTotalAmount;
        PromoApplied = promoApplied;
    }

    public Sale() {}
}