namespace InventorySystem.Domain.Shared.ValueObjects;

public class TenantId : ValueObject<Guid, TenantId>
{
    private TenantId(Guid value) : base(value) {}

    public static TenantId Create(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Tenant Id cannot be empty guid");
        }
        return new TenantId(value);
    }
}