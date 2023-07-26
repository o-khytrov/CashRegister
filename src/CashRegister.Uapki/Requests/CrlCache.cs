using Newtonsoft.Json;

namespace CashRegister.Uapki.Requests;

internal class CrlCache
{
    [JsonProperty("path")]
    public string? Path { get; set; }
}