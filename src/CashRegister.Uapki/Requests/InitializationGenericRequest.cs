namespace CashRegister.Uapki.Requests;

internal class InitializationGenericRequest : BaseGenericRequest<InitializationParameters>
{
    private const string MethodName = "INIT";

    public InitializationGenericRequest()
        : base(MethodName)
    {
    }
}