using CashRegister.Api.Models.Dfs.Responses.Entities;

namespace CashRegister.Api.Models.Dfs.Responses;

/// <summary>
///     Відповідь на запит господарських одиниць.
/// </summary>
public class BusinessUnitResponse
{
    public BusinessUnit[] TaxObjects { get; set; }
}