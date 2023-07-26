using CashRegister.Uapki.Requests;
using CashRegister.Uapki.Responses;

namespace CashRegister.Uapki;

public partial class UapkiLibrary
{
    public static List<CertificateStorageRecord> AddCertificates(byte[][] certificates, bool permanent)
    {
        return Process<AddCertificateResult>(new AddCertificateRequest(certificates, permanent)).Certificates!;
    }

    public static List<CertificateStorageRecord> AddCertificates(byte[] bundle, bool permanent)
    {
        return Process<AddCertificateResult>(new AddCertificateRequest(bundle, permanent)).Certificates!;
    }
}