using Newtonsoft.Json;

namespace CashRegister.Uapki.Requests;

public class KeyInfo
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("mechanismId")]
    public string? MechanismId { get; set; }

    [JsonProperty("parameterId")]
    public string? ParameterId { get; set; }

    [JsonProperty("signAlgo")]
    public List<string>? SigningAlgorithms { get; set; }

    [JsonProperty("label")]
    public string? Label { get; set; }

    public string? CertificateId { get; set; }

    public byte[]? Certificate { get; set; }

    public bool IsSelected { get; internal set; }
}