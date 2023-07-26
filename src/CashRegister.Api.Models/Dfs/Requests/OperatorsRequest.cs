namespace CashRegister.Api.Models.Dfs.Requests;

/// <summary>
///     Запит переліку операторів (касирів) для суб’єкта господарювання
/// </summary>
public class OperatorsRequest : BaseRequest
{
    public OperatorsRequest()
        : base("Operators")
    {
    }
}