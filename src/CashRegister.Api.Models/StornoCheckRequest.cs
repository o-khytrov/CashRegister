namespace CashRegister.Api.Models;

/// <summary>
/// Запит на сторнування останнього чека.
/// </summary>
public class StornoCheckRequest
{
    /// <summary>
    ///     Фіскальний номер ПРРО.
    /// </summary>
    public ulong RegistrarNumFiscal { get; set; }

    /// <summary>
    ///     Фіскальний номер чека.
    /// </summary>
    public ulong NumFiscal { get; set; }
}