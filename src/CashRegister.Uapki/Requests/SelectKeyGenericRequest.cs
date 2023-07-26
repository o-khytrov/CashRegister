namespace CashRegister.Uapki.Requests;

internal class SelectKeyGenericRequest : BaseGenericRequest<IdParameters>
{
    private const string MethodName = "SELECT_KEY";

    public SelectKeyGenericRequest(string? id)
        : base(MethodName)
    {
        Parameters = new IdParameters
        {
            Id = id
        };
    }
}