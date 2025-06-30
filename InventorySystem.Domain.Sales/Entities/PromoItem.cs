using InventorySystem.Domain.Shared.ValueObjects;

namespace InventorySystem.Domain.Sales.Entities;

public class PromoItem
{
    public EntityId Id { get; }
    public EntityId ItemId { get; }
    public EntityId PromoId { get; }
    public EntityId TenantId { get; }
    
    // Navigation Properties
    public Promo Promo { get; }

    public PromoItem(
        Guid id,
        Guid itemId,
        Guid promoId,
        Guid tenantId
        )
    {
        Id = EntityId.Create(id);
        ItemId = EntityId.Create(itemId);
        PromoId = EntityId.Create(promoId);
        TenantId = EntityId.Create(tenantId);
    }

    public PromoItem()
    {
    }

}