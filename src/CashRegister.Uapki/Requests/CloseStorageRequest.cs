namespace CashRegister.Uapki.Requests;

internal class CloseStorageRequest : BaseRequest
{
    private const string MethodName = "CLOSE";

    public CloseStorageRequest()
        : base(MethodName)
    {
    }
}