namespace CashRegister.Uapki.Requests;

internal class CertificateInformationGenericRequest : BaseGenericRequest<CertificateInformationParameters>
{
    private const string MethodName = "CERT_INFO";

    public CertificateInformationGenericRequest(byte[] certificate)
        : base(MethodName)
    {
        Parameters = new CertificateInformationParameters
        {
            BytesBase64 = Convert.ToBase64String(certificate)
        };
    }

    public CertificateInformationGenericRequest(string certificateId)
        : base(MethodName)
    {
        Parameters = new CertificateInformationParameters
        {
            CertificateIdBase64 = certificateId
        };
    }
}