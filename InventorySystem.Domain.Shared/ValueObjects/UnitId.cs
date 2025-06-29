namespace InventorySystem.Domain.Shared.ValueObjects;

public class UnitId: ValueObject<Guid, UnitId>
{
    private UnitId(Guid value): base(value) { }
    
    public static UnitId Create(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Unit Id cannot be empty guid");
        }
        return new UnitId(value);
    }
}