using InventorySystem.Domain.Inventory.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InventorySystem.Infrastructure.Converters;

public class ItemIdConverter: ValueConverter<ItemId, Guid>
{
    public ItemIdConverter(): base(
        itemId => itemId.Value,
        guid => ItemId.Create(guid)
        ) {}
}