using InventorySystem.Domain.Shared.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InventorySystem.Infrastructure.Converters;

public class EntityIdConverter: ValueConverter<EntityId, Guid>
{
    public EntityIdConverter() : base(
        id => id.Value,
        guid => EntityId.Create(guid)
        ) {}
}