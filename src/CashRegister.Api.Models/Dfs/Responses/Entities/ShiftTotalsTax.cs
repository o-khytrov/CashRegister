namespace CashRegister.Api.Models.Dfs.Responses.Entities;

/// <summary>
///     Податки/збори.
/// </summary>
public class ShiftTotalsTax
{
    /// <summary>
    ///     Код виду податку/збору.
    /// </summary>
    public int Type { get; set; }

    /// <summary>
    ///     Найменування виду податку/збору.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Літерне позначення виду і ставки податку/збору.
    /// </summary>
    public string Letter { get; set; }

    /// <summary>
    ///     Відсоток податку/збору.
    /// </summary>
    public decimal Prc { get; set; }

    /// <summary>
    ///     Ознаку податку/збору не включеного у вартість.
    /// </summary>
    public bool Sign { get; set; }

    /// <summary>
    ///     Сума обсягів для розрахування податку/збору.
    /// </summary>
    public decimal Turnover { get; set; }

    /// <summary>
    ///     Вихідна сума для розрахування податку/збору.
    /// </summary>
    public decimal? SourceSum { get; set; }

    /// <summary>
    ///     Сума податку/збору.
    /// </summary>
    public decimal Sum { get; set; }
}