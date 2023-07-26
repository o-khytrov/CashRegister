using CashRegister.Uapki.Requests;
using CashRegister.Uapki.Responses;

namespace CashRegister.Uapki;

public partial class UapkiLibrary
{
    public static Storage OpenStorage(IStorageOpenParameters openParameters)
    {
        if (openParameters == null)
            throw new ArgumentNullException(nameof(openParameters), "Provide Storage open parameters");

        var storage = Process<Storage>(new OpenStorageGenericRequest(openParameters));

        storage.Id = openParameters.Storage;
        storage.ProviderId = openParameters.Provider;

        return storage;
    }

    internal static void CloseStorage()
    {
        Process<object>(new CloseStorageRequest());
    }
}