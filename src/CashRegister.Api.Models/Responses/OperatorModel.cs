namespace CashRegister.Api.Models.Responses;

public class OperatorModel
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