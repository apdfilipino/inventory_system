using InventorySystem.Domain.Shared.ValueObjects;

namespace InventorySystem.Domain.Inventory.ValueObjects;

public class ItemId: ValueObject<Guid, ItemId>
{
    private ItemId(Guid value): base(value) {}

    public static ItemId Create(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Item Id cannot be an empty guid");
        }
        return new ItemId(value);
    }
}