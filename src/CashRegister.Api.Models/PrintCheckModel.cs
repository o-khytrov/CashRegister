namespace CashRegister.Api.Models;

public class PrintCheckModel
{
    public PrintCheckModel()
    {
        Rows = new List<PrintCheckRow>();
    }

    public string OrganizationName { get; set; }

    public string BusinessUnitName { get; set; }

    public string TaxNumber { get; set; }

    public string Cashier { get; set; }

    public string CashRegisterId { get; set; }

    public DateTime DateTime { get; set; }

    public string? InternalNumber { get; set; }

    public string? FiscalNumber { get; set; }

    public string? Url { get; set; }

    public decimal Total { get; set; }

    public ICollection<PrintCheckRow> Rows { get; set; }

    public string BarcodeBase64 { get; set; }
}