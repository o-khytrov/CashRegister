namespace CashRegister.Api.Models.Dfs.Requests;

/// <summary>
///     Запит відомостей про документ за локальним номером.
/// </summary>
public class DocumentInfoByLocalNumberRequest : BaseRequest
{
    public DocumentInfoByLocalNumberRequest()
        : base("DocumentInfoByLocalNum")
    {
    }

    /// <summary>
    ///     Локальный номер чека.
    /// </summary>
    public long NumLocal { get; set; }

    /// <summary>
    ///     Фискальный номер ФР.
    /// </summary>
    public long NumFiscal { get; set; }
}