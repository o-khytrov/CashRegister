using Newtonsoft.Json;

namespace CashRegister.Uapki.Requests;

internal class TspAddress
{
    [JsonProperty("url")]
    public string? Url { get; set; }
}