using Newtonsoft.Json;

namespace CashRegister.Uapki.Requests;

internal class CertificateCache
{
    [JsonProperty("path")]
    public string? Path { get; set; }

    [JsonProperty("trustedCerts")]
    public IEnumerable<string>? TrustedCertificates { get; set; }
}