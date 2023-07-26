namespace CashRegister.Api.Models.Responses;

/// <summary>
///     РРО.
/// </summary>
public class TransactionsRegistrarModel
{
    /// <summary>
    ///     Фіскальний номер.
    /// </summary>
    public ulong NumFiscal { get; set; }

    /// <summary>
    ///     Локальний номер РРО.
    /// </summary>
    public ulong NumLocal { get; set; }

    /// <summary>
    ///     Найменування РРО.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    ///     Ознака скасованої реєстрації ПРРО, на якому наразі не закрито зміну.
    /// </summary>
    public bool Closed { get; set; }
}