using InventorySystem.Domain.Sales.ValueObjects;
using InventorySystem.Domain.Shared.ValueObjects;

namespace InventorySystem.Domain.Sales.Entities;

public class Sale
{
    public SaleId Id { get; }
    public TenantId TenantId { get; }
    public DateTime CreatedAt { get; }
    public Guid CreatedBy { get; } // TODO: Update User is ready
    public decimal TotalAmount { get; }
    public decimal EffectiveTotalAmount { get; }
    public bool PromoApplied { get; }
    
    // Navigation Property
    public List<Promo> Promos { get; }

    public Sale(Guid id,
        Guid tenantId,
        DateTime createdAt,
        Guid createdBy,
        decimal totalAmount,
        decimal effectiveTotalAmount,
        bool promoApplied)
    {
        Id = SaleId.Create(id);
        TenantId = TenantId.Create(tenantId);
        CreatedAt = createdAt;
        CreatedBy = createdBy;
        TotalAmount = totalAmount;
        EffectiveTotalAmount = effectiveTotalAmount;
        PromoApplied = promoApplied;
    }

    public Sale() {}
}