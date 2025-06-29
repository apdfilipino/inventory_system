namespace InventorySystem.Domain.Shared.ValueObjects;

public abstract class ValueObject<T, TValueObject> : IEquatable<T>
    where T : notnull
    where TValueObject : ValueObject<T, TValueObject>
{
    public T Value { get; }
    
    protected ValueObject(T value)
    {
        if (value is null) throw new ArgumentNullException(nameof(value));
        Value = value;
    }
    
    private bool Equals(ValueObject<T, TValueObject> other)
    {
        return Value.Equals(other);
    }

    public bool Equals(T? other)
    {
        return Value.Equals(other);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((ValueObject<T, TValueObject>)obj);
    }

    public static bool operator ==(ValueObject<T, TValueObject>? left, ValueObject<T, TValueObject>? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(ValueObject<T, TValueObject>? left, ValueObject<T, TValueObject>? right)
    {
        return !Equals(left, right);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    private static bool Equals(ValueObject<T, TValueObject> x, ValueObject<T, TValueObject> y)
    {
        if (x is null && y is null) return true;
        if (x is null || y is null) return false;
        return x.Equals(y);
    }
}