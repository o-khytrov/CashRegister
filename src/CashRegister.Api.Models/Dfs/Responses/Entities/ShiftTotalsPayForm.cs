using CashRegister.Api.Models.Dfs.Enums;

namespace CashRegister.Api.Models.Dfs.Responses.Entities;

/// <summary>
///     Підсумки по формам оплати.
/// </summary>
public class ShiftTotalsPayForm
{
    /// <summary>
    ///     Код форми оплати.
    /// </summary>
    public EPaymentForm PayFormCode { get; set; }

    /// <summary>
    ///     Назва форми оплати.
    /// </summary>
    public string PayFormName { get; set; }

    /// <summary>
    ///     Сума оплати.
    /// </summary>
    public decimal Sum { get; set; }
}