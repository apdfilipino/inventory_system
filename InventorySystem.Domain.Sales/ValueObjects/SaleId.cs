using InventorySystem.Domain.Shared.ValueObjects;

namespace InventorySystem.Domain.Sales.ValueObjects;

public class SaleId: ValueObject<Guid, SaleId>
{
    private SaleId(Guid value) : base(value) { }

    public static SaleId Create(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id cannot be empty", nameof(id));
        }
        return new SaleId(id);
    }
}