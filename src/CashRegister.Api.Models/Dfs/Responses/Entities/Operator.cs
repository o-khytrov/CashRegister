namespace CashRegister.Api.Models.Dfs.Responses.Entities;

public class Operator
{
    /// <summary>
    ///     Ідентифікатор ключа суб’єкта.
    /// </summary>
    public string SubjectKeyId { get; set; }

    /// <summary>
    ///     Реєстраційний номер особи оператора (ЄДРПОУ,ДРФО,Картка платника податків).
    /// </summary>
    public string RegNum { get; set; }

    /// <summary>
    ///     Старший касир.
    /// </summary>
    public bool ChiefCashier { get; set; }
}