using InventorySystem.Domain.Inventory.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InventorySystem.Infrastructure.Converters;

public class InventoryIdConverter: ValueConverter<InventoryId, Guid>
{
    public InventoryIdConverter(): base(
        id => id.Value,
        guid => InventoryId.Create(guid)
        ) { }
}