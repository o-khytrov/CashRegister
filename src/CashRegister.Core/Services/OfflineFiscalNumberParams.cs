namespace CashRegister.Models.Services;

/// <summary>
/// Параметри для формування фіскального номеру оффлайн документа 
/// </summary>
public class OfflineFiscalNumberParams
{
    public string OfflineSessionId { get; set; }

    public ulong OfflineSessionDocumentNumber { get; set; }

    public DateTime DocumentDateTime { get; set; }

    public ulong CashRegisterFiscalNumber { get; set; }

    public ulong DocumentLocalNumber { get; set; }

    public ulong CashRegisterLocalNumber { get; set; }

    public decimal? Sum { get; set; }

    public string? PreviousDocumentHash { get; set; }

    public ulong OfflineSeed { get; set; }
}