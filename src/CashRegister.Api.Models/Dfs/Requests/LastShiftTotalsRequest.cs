namespace CashRegister.Api.Models.Dfs.Requests;

public class LastShiftTotalsRequest : BaseRequest
{
    /// <summary>
    ///     Запит підсумків останньої зміни.
    /// </summary>
    public LastShiftTotalsRequest()
        : base("LastShiftTotals")
    {
    }

    public ulong NumFiscal { get; set; }
}