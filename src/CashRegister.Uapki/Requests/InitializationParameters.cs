using Newtonsoft.Json;

namespace CashRegister.Uapki.Requests;

internal class InitializationParameters
{
    [JsonProperty("cmProviders")]
    public CmProviders? CmProviders { get; set; }

    [JsonProperty("certCache")]
    public CertificateCache? CertificateCache { get; set; }

    [JsonProperty("crlCache")]
    public CrlCache? CrlCache { get; set; }

    [JsonProperty("tsp")]
    public TspAddress? TspAddress { get; set; }

    [JsonProperty("offline")]
    public bool Offline { get; set; }
}