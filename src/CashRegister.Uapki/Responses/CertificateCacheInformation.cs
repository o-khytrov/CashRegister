using Newtonsoft.Json;

namespace CashRegister.Uapki.Responses;

public class CertificateCacheInformation
{
    [JsonProperty("countCerts")]
    public int CertificateCount { get; set; }

    [JsonProperty("countTrustedCerts")]
    public int TrustedCertificatesCount { get; set; }
}

internal class Csr
{
    [JsonProperty("bytes")]
    public string? BytesBase64 { get; set; }
}