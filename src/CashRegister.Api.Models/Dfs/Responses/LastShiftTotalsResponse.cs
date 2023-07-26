using CashRegister.Api.Models.Dfs.Responses.Entities;
using CashRegister.Api.Models.Dfs.Responses.Enums;

namespace CashRegister.Api.Models.Dfs.Responses;

public class LastShiftTotalsResponse
{
    public ECashRegisterState ShiftState { get; set; }

    public bool ZRepPresent { get; set; }

    /// <summary>
    ///     Підсу
    /// </summary>
    public ShiftTotals Totals { get; set; }
}