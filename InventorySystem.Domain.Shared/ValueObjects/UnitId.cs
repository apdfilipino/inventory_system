namespace InventorySystem.Domain.Shared.ValueObjects;

public class UnitId
{
    public Guid Value { get; }

    private UnitId(Guid value)
    {
        Value = value;
    }
    
    public static UnitId Create(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Unit Id cannot be empty guid");
        }
        return new UnitId(value);
    }
}