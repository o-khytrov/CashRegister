using Newtonsoft.Json;

namespace CashRegister.Uapki.Responses;

public class InitializationInformation
{
    [JsonProperty("certCache")]
    public CertificateCacheInformation? CertificateCache { get; set; }

    [JsonProperty("crlCache")]
    public ClrCacheInformation? ClrCache { get; set; }

    [JsonProperty("countCmProviders")]
    public int CmProvidersCount { get; set; }

    [JsonProperty("offline")]
    public bool Offline { get; set; }

    [JsonProperty("tsp")]
    public TspInformation? Tsp { get; set; }
}