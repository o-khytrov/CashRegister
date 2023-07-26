using System.ComponentModel.DataAnnotations.Schema;
using CashRegister.Api.Models.Dfs.Responses.Enums;

namespace CashRegister.Models.DbModels;

public class CashRegisterStateDbModel
{
    [Column("cash_register_fiscal_number")]
    public ulong CashRegisterFiscalNumber { get; set; }

    [Column("shift_id")]
    public ulong ShiftId { get; set; }

    [Column("is_z_report_present")]
    public bool IsZReportPresent { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("subject_key_id")]
    public string? SubjectKeyId { get; set; }

    [Column("first_local_number")]
    public ulong FirstLocalNumber { get; set; }

    [Column("next_local_number")]
    public ulong NextLocalNumber { get; set; }

    [Column("last_fiscal_number")]
    public string LastFiscalNumber { get; set; }

    [Column("is_offline_supported")]
    public bool IsOfflineSupported { get; set; }

    [Column("is_chief_cashier")]
    public bool IsChiefCashier { get; set; }

    [Column("date_time")]
    public DateTime DateTime { get; set; }

    [Column("next_local_number_for_send")]
    public ulong NextLocalNumberForSend { get; set; }

    [Column("offline_session_id")]
    public string? OfflineSessionId { get; set; }

    [Column("offline_seed")]
    public ulong OfflineSeed { get; set; }

    [Column("offline_next_local_number")]
    public ulong OfflineNextLocalNumber { get; set; }

    [Column("shift_state")]
    public ECashRegisterState State { get; set; }

    public bool IsTesting { get; set; }
}