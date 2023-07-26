using CashRegister.Uapki.Requests;
using CashRegister.Uapki.Responses;

namespace CashRegister.Uapki;

public partial class UapkiLibrary
{
    public static byte[] GenerateCertificateSigningRequest(string? signAlgorithm = null)
    {
        var result = Process<Csr>(new GetCsrGenericRequest(signAlgorithm));
        return Convert.FromBase64String(result.BytesBase64!);
    }

    public static IEnumerable<SignatureResult> Sign(Sign sign)
    {
        return Process<SigningResponse>(new SignGenericRequest(sign)).Signatures!;
    }
}