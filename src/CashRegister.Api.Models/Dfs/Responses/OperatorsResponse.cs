using CashRegister.Api.Models.Dfs.Responses.Entities;

namespace CashRegister.Api.Models.Dfs.Responses;

/// <summary>
///     Перелік операторів, що зареєстровані для суб'єкта господарювання,
///     реєстраційний номер якого (ЄДРПОУ, ДРФО, Картка платника податків) міститься у сертифікаті
///     КЕП, яким засвідчений запит.
/// </summary>
public class OperatorsResponse
{
    /// <summary>
    ///     Унікальний ідентифікатор відповіді.
    /// </summary>
    public Guid UID { get; set; }

    /// <summary>
    ///     Реєстраційний номер суб'єкта господарювання (ЄДРПОУ,ДРФО,Картка платника податків).
    /// </summary>
    public string Tin { get; set; }

    /// <summary>
    ///     Перелік операторів.
    /// </summary>
    public Operator[] Operators { get; set; }
}