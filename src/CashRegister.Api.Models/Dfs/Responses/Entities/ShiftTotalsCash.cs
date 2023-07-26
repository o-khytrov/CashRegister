namespace CashRegister.Api.Models.Dfs.Responses.Entities;

/// <summary>
///     Підсумки видачі готівки.
/// </summary>
public class ShiftTotalsCash
{
    /// <summary>
    ///     Загальна сумма.
    /// </summary>
    public decimal Sum { get; set; }

    /// <summary>
    ///     Загальна сумма комісії.
    /// </summary>
    public decimal Commission { get; set; }

    /// <summary>
    ///     Кількість чеків.
    /// </summary>
    public int OrdersCount { get; set; }
}