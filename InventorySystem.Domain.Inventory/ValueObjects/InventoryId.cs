using InventorySystem.Domain.Shared.ValueObjects;

namespace InventorySystem.Domain.Inventory.ValueObjects;

public class InventoryId: ValueObject<Guid, InventoryId>
{
    private InventoryId(Guid value): base(value) { }

    public static InventoryId Create(Guid id)
    {
        if (Guid.Empty == id)
        {
            throw new ArgumentException($"{nameof(id)} cannot be empty");
        }
        return new InventoryId(id);
    }
}