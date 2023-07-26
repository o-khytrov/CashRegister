using CashRegister.Api.Models.Dfs.Enums;

namespace CashRegister.Api.Models;

public class CheckModel
{
    public ulong CashRegisterId { get; set; }

    public ulong Number { get; set; }

    public IEnumerable<CheckRow>? Rows { get; set; }

    public IEnumerable<CheckPayment> Payments { get; set; }

    public ulong? OrderReturnNumber { get; set; }
}

public class CheckRow
{
    public string? ItemName { get; set; }

    public decimal RetailPrice { get; set; }

    public decimal FinalPrice { get; set; }

    public decimal Amount { get; set; }

    public decimal SumDelta { get; set; }

    public decimal Sum { get; set; }
    public decimal TaxSum { get; set; }

    public string? Tax { get; set; }

    public int UnitCode { get; set; }
}

public class CheckPayment
{
    public EPaymentForm Form { get; set; }

    public decimal Sum { get; set; }

    public decimal Provided { get; set; }

    public decimal Remains => Provided - Sum;
}