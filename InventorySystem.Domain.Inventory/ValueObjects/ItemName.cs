using InventorySystem.Domain.Shared.ValueObjects;

namespace InventorySystem.Domain.Inventory.ValueObjects;

public class ItemName: ValueObject<string, ItemName>
{
    private ItemName(string value): base(value) {}

    public static ItemName Create(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Item name cannot be null or empty");
        }
        return new ItemName(value);
    }
}