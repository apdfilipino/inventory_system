using InventorySystem.Domain.Shared.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InventorySystem.Infrastructure.Converters;

public class UnitIdConverter: ValueConverter<UnitId, Guid>
{
    public UnitIdConverter(): base(
        unitId => unitId.Value,
        guid => UnitId.Create(guid)
        ) { }
}