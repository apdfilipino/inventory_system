using System.Linq.Expressions;
using InventorySystem.Domain.Shared.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InventorySystem.Infrastructure.Converters;

public class TenantIdConverter: ValueConverter<TenantId, Guid>
{
    public TenantIdConverter() : base(
        tenantId => tenantId.Value,
        guid => TenantId.Create(guid)
        ) {}
}