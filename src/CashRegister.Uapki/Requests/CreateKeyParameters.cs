using Newtonsoft.Json;

namespace CashRegister.Uapki.Requests;

internal class CreateKeyParameters
{
    [JsonProperty("mechanism")]
    public string? Mechanism { get; set; }

    [JsonProperty("parameter")]
    public string? Parameter { get; set; }

    [JsonProperty("label")]
    public string? Label { get; set; }
}