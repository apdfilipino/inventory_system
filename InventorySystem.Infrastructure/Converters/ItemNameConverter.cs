using InventorySystem.Domain.Inventory.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InventorySystem.Infrastructure.Converters;

public class ItemNameConverter: ValueConverter<ItemName, string>
{
    public ItemNameConverter(): base(
        itemName => itemName.Value,
        value => ItemName.Create(value)
        ) {}
}