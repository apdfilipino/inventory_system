using InventorySystem.Domain.Inventory.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InventorySystem.Infrastructure.Converters;

public class CategoryIdConverter: ValueConverter<CategoryId, Guid>
{
    public CategoryIdConverter() : base(
        categoryId => categoryId.Value,
        Guid => CategoryId.Create(Guid)
        ) {}
}