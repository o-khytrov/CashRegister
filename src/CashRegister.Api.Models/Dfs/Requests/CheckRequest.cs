namespace CashRegister.Api.Models.Dfs.Requests;

/// <summary>
///     Запит чека.
/// </summary>
public class CheckRequest : BaseRequest
{
    public CheckRequest()
        : base("Check")
    {
    }

    /// <summary>
    ///     Фіскальний номер ПРРО.
    /// </summary>
    public long RegistrarNumFiscal { get; set; }

    /// <summary>
    ///     Фіскальний номер чека.
    /// </summary>
    public long NumFiscal { get; set; }

    /// <summary>
    ///     Ознака запиту оригінального документа, надісланого продавцем.
    /// </summary>
    public bool Original { get; set; }
}