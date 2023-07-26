using Newtonsoft.Json;

namespace CashRegister.Uapki.Requests;

internal class CertificateInformationParameters : CertificateIdParameters
{
    [JsonProperty("bytes")]
    public string? BytesBase64 { get; set; }
}