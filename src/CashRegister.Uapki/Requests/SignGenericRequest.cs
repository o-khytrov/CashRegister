namespace CashRegister.Uapki.Requests;

internal class SignGenericRequest : BaseGenericRequest<Sign>
{
    private const string MethodName = "SIGN";

    public SignGenericRequest(Sign parameters)
        : base(MethodName)
    {
        Parameters = parameters;
    }
}