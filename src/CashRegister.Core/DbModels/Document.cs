using CashRegister.Api.Models.Dfs.Responses.Enums;

namespace CashRegister.Models.DbModels;

public class Document
{
    public long Id { get; set; }

    public ulong CashRegisterId { get; set; }

    public ulong LocalNumber { get; set; }

    public EDfsDocumentType DocumentType { get; set; }

    public string? FiscalNumber { get; set; }

    public string? Xml { get; set; }

    public string? Ticket { get; set; }
}