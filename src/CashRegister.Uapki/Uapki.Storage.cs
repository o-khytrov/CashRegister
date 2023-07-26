using CashRegister.Uapki.Requests;
using CashRegister.Uapki.Responses;

namespace CashRegister.Uapki;

public partial class UapkiLibrary
{
    public static List<KeyInfo> StorageKeysList()
    {
        return Process<KeysList>(new KeysRequest()).Keys!;
    }

    public static void SelectKey(KeyInfo key)
    {
        var additionalInfo = Process<SelectedKeyInfo>(new SelectKeyGenericRequest(key.Id));

        key.SigningAlgorithms = additionalInfo.SigningAlgorithms;
        key.CertificateId = additionalInfo.CertificateId;
        key.IsSelected = true;
    }
}