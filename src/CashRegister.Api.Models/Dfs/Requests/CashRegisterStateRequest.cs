namespace CashRegister.Api.Models.Dfs.Requests;

/// <summary>
///     Запит стану ПРРО.
/// </summary>
public class CashRegisterStateRequest : BaseRequest
{
    public CashRegisterStateRequest()
        : base("TransactionsRegistrarState")
    {
    }

    /// <summary>
    ///     Фіскальний номер ПРРО.
    /// </summary>
    public long NumFiscal { get; set; }

    /// <summary>
    ///     Ідентифікатор офлайн сесії,
    ///     для якої будуть надіслані пакети документів (не обов’язковий).
    /// </summary>
    public long? OfflineSessionId { get; set; }

    /// <summary>
    ///     Секретне число" для обчислення фіскального
    ///     номера офлайн документа офлайн сесії, для якої будуть надіслані пакети
    ///     документів (не обов’язковий).
    /// </summary>
    public long? OfflineSeed { get; set; }

    /// <summary>
    ///     Ознака запиту відомостей об’єкту оподаткування.
    /// </summary>
    public bool IncludeTaxObject { get; set; }
}