namespace InventorySystem.Domain.Inventory.ValueObjects;

public class ItemName: IEquatable<ItemName>
{
    public string Value { get; }

    private ItemName(string value)
    {
        Value = value;
    }

    public static ItemName Create(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Item Name cannot be null or empty");
        }
        return new ItemName(value);
    }

    public bool Equals(ItemName? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Value == other.Value;
    }
    
    private static bool Equals(ItemName x, ItemName y)
    {
        if (x == null && y == null) return true;
        if (x == null || y == null) return false;
        return string.Equals(x.Value, y.Value, StringComparison.OrdinalIgnoreCase);
    }

    public static bool operator !=(ItemName x, ItemName y)
    {
        return !Equals(x, y);
    }

    public static bool operator ==(ItemName x, ItemName y)
    {
        return Equals(x, y);
    }
}