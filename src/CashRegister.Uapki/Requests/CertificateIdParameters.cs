using Newtonsoft.Json;

namespace CashRegister.Uapki.Requests;

internal class CertificateIdParameters
{
    [JsonProperty("certId")]
    public string? CertificateIdBase64 { get; set; }
}