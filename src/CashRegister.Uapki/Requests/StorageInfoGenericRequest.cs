namespace CashRegister.Uapki.Requests;

internal class StorageInfoGenericRequest : BaseGenericRequest<StorageInfoParameters>
{
    private const string MethodName = "STORAGE_INFO";

    public StorageInfoGenericRequest(string providerId, string storageId)
        : base(MethodName)
    {
        Parameters = new StorageInfoParameters
        {
            Provider = providerId,
            Storage = storageId
        };
    }
}