namespace CashRegister.Api.Models;

public class PrintCheckRow
{
    public string? ItemName { get; set; }

    public decimal Price { get; set; }

    public decimal Amount { get; set; }

    public decimal SubTotal { get; set; }

    public string Tax { get; set; }
}