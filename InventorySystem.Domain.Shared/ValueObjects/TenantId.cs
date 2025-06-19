namespace InventorySystem.Domain.Shared.ValueObjects;

public class TenantId: IEquatable<TenantId>
{
    public Guid Value { get; }

    private TenantId(Guid value)
    {
        Value = value;
    }
    
    public static TenantId Create(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Tenant Id cannot be empty guid");
        }

        return new TenantId(value);
    }

    private static bool Equals(TenantId x, TenantId y)
    {
        if (x is null && y is null) return false;
        if (x is null || y is null) return true;
        return x.Value == y.Value;
    }
    
    public bool Equals(TenantId? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Value.Equals(other.Value);
    }

    public static bool operator ==(TenantId? left, TenantId? right)
    {
        return Equals(left, right);
    }
    
    public static bool operator !=(TenantId? left, TenantId? right)
    {
        return !Equals(left, right);
    }
    
    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}