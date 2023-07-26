namespace CashRegister.Api.Models.Dfs.Responses.Entities;

/// <summary>
///     Підсумки по зміні.
/// </summary>
public class ShiftTotals
{
    /// <summary>
    ///     Підсумки реалізації.
    /// </summary>
    public ShiftTotalsOrderType Real { get; set; }

    /// <summary>
    ///     Підсумки повернення.
    /// </summary>
    public ShiftTotalsOrderType Ret { get; set; }

    /// <summary>
    ///     Підсумки видачі готівки.
    /// </summary>
    public ShiftTotalsCash Cash { get; set; }

    /// <summary>
    ///     Службове внесення/Отримання авансу/Отримання підкріплення.
    /// </summary>
    public decimal ServiceInput { get; set; }

    /// <summary>
    ///     Службова видача/Інкасація.
    /// </summary>
    public decimal ServiceOutput { get; set; }
}