using System.ComponentModel.DataAnnotations.Schema;
using CashRegister.Api.Models.Dfs.Responses.Enums;

namespace CashRegister.Models.DbModels;

public class OfflineDocument
{
    [Column("local_number")]
    public ulong LocalNumber { get; set; }

    [Column("fiscal_number")]
    public string? FiscalNumber { get; init; }

    [Column("cash_register_fiscal_number")]
    public ulong CashRegisterFiscalNumber { get; set; }

    [Column("offline_document_number")]
    public ulong OfflineSessionDocumentNumber { get; set; }

    [Column("offline_session_id")]
    public string? OfflineSessionId { get; set; }

    [Column("hash")]
    public string? Hash { get; init; }

    [Column("xml")]
    public string? Xml { get; set; }

    [Column("document_type")]
    public EDfsDocumentType Type { get; set; }
}