using Newtonsoft.Json;

namespace CashRegister.Uapki.Requests;

internal class AllowedProvider
{
    [JsonProperty("lib")]
    public string? Library { get; set; }
}

internal class AddCertificateRequest : BaseGenericRequest<AddCertificateParameters>
{
    private const string MethodName = "ADD_CERT";

    public AddCertificateRequest(byte[][] certificates, bool permanent)
        : base(MethodName)
    {
        Parameters = new AddCertificateParameters
        {
            CertificatesBase64 = certificates.Select(s => Convert.ToBase64String(s)),
            Permanent = permanent
        };
    }

    public AddCertificateRequest(byte[] bundle, bool permanent)
        : base(MethodName)
    {
        Parameters = new AddCertificateParameters
        {
            Bundle = Convert.ToBase64String(bundle),
            Permanent = permanent
        };
    }
}

internal class AddCertificateParameters
{
    [JsonProperty("certificates")]
    public IEnumerable<string>? CertificatesBase64 { get; set; }

    [JsonProperty("bundle")]
    public string? Bundle { get; set; }

    [JsonProperty("permanent")]
    public bool Permanent { get; set; }
}