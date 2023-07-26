using CashRegister.Api.Models.Dfs.Responses.Enums;

namespace CashRegister.Api.Models.Dfs.Responses;

/// <summary>
///     Відповідь на запит про стан ПРРО.
/// </summary>
public class CashRegisterStateResponse
{
    public ECashRegisterState ShiftState { get; set; }

    public long ShiftId { get; set; }

    public string OpenShiftFiscalNum { get; set; }

    public bool ZRepPresent { get; set; }

    public string Name { get; set; }

    public string SubjectKeyId { get; set; }

    public long FirstLocalNum { get; set; }

    public long NextLocalNum { get; set; }

    public string LastFiscalNum { get; set; }

    public bool OfflineSupported { get; set; }

    public bool ChiefCashier { get; set; }

    public long NextLocalNumForSend { get; set; }

    public long? OfflineSessionId { get; set; }

    public long? OfflineSeed { get; set; }

    public long? OfflineNextLocalNum { get; set; }

    public int? OfflineSessionDuration { get; set; }

    public int? OfflineSessionsMonthlyDuration { get; set; }
}