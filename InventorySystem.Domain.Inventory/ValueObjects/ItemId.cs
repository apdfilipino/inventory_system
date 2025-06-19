namespace InventorySystem.Domain.Inventory.ValueObjects;

public class ItemId: IEquatable<ItemId>
{
    public Guid Value { get; }

    private ItemId(Guid value)
    {
        Value = value;
    }

    public static ItemId Create(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Item Id cannot be an empty guid");
        }
        return new ItemId(value);
    }
    
    public bool Equals(ItemId? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Value.Equals(other.Value);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}