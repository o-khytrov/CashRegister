namespace CashRegister.Api.Models.Dfs.Responses.Entities;

/// <summary>
///     Господарська одиниця.
/// </summary>
public class BusinessUnit
{
    /// <summary>
    ///     Адреса ГО.
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    ///     Ідентифікатор запису ГО.
    /// </summary>
    public long Entity { get; set; }

    /// <summary>
    ///     Найменування суб'єкта господарювання.
    /// </summary>
    public string OrgName { get; set; }

    /// <summary>
    ///     Найменування ГО.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Код ЄДРПОУ/ДРФО платника.
    /// </summary>
    public string Tin { get; set; }

    /// <summary>
    ///     Податковий номер платника ПДВ.
    /// </summary>
    public string Ipn { get; set; }

    /// <summary>
    ///     Перелік РРО зареєстрованих для ГО.
    /// </summary>
    public TransactionsRegistrarItem[] TransactionsRegistrars { get; set; }
}