namespace CashRegister.Uapki.Requests;

internal class OpenStorageGenericRequest : BaseGenericRequest<IStorageOpenParameters>
{
    private const string MethodName = "OPEN";

    public OpenStorageGenericRequest(IStorageOpenParameters storageOpenParameters)
        : base(MethodName)
    {
        Parameters = storageOpenParameters;
    }
}