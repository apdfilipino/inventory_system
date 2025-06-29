using InventorySystem.Domain.Sales.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InventorySystem.Infrastructure.Converters;

public class SaleIdConverter: ValueConverter<SaleId, Guid>
{
    public SaleIdConverter(): base(
        saleId => saleId.Value,
        guid => SaleId.Create(guid)
        ) {}    
}