using InventorySystem.Domain.Shared.ValueObjects;

namespace InventorySystem.Domain.Inventory.ValueObjects;

public class CategoryId: ValueObject<Guid, CategoryId>
{
    private CategoryId(Guid value): base(value) { }
    
    public static CategoryId Create(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException($"{nameof(id)} cannot be empty");
        }
        return new CategoryId(id);
    }
}