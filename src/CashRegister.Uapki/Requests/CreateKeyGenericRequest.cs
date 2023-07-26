namespace CashRegister.Uapki.Requests;

internal class CreateKeyGenericRequest : BaseGenericRequest<CreateKeyParameters>
{
    private const string MethodName = "CREATE_KEY";

    public CreateKeyGenericRequest(CreateKeyParameters parameters)
        : base(MethodName)
    {
        Parameters = parameters;
    }
}