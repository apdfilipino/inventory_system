namespace InventorySystem.Domain.Shared.ValueObjects;

public class EntityId: ValueObject<Guid, EntityId>
{
    private EntityId(Guid value) : base(value)
    {
    }

    public static EntityId Create(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("EntityId cannot be an empty guid");
        }
        return new EntityId(value);
    }
    
    public static EntityId Create(Guid? value)
    {
        if (!value.HasValue)
        {
            throw new ArgumentException("EntityId cannot be null");
        }
        return EntityId.Create(value.Value);
    }
}