namespace CashRegister.Api.Models.Dfs.Responses.Entities;

/// <summary>
///     РРО.
/// </summary>
public class TransactionsRegistrarItem
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
    public string Name { get; set; }

    /// <summary>
    ///     Ознака скасованої реєстрації ПРРО, на якому наразі не закрито зміну.
    /// </summary>
    public bool Closed { get; set; }
}