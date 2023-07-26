namespace CashRegister.Api.Models.Dfs.Responses.Entities;

/// <summary>
///     Підсумки по типу чека.
/// </summary>
public class ShiftTotalsOrderType
{
    /// <summary>
    ///     Загальна сума.
    /// </summary>
    public decimal Sum { get; set; }

    /// <summary>
    ///     Кількість чеків.
    /// </summary>
    public int OrdersCount { get; set; }

    /// <summary>
    ///     Підсумки по формам оплати.
    /// </summary>
    public List<ShiftTotalsPayForm> PayForm { get; set; }

    /// <summary>
    ///     Податки/збори.
    /// </summary>
    public List<ShiftTotalsTax> Tax { get; set; }
}