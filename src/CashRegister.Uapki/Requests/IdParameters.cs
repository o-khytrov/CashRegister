using Newtonsoft.Json;

namespace CashRegister.Uapki.Requests;

internal class IdParameters
{
    [JsonProperty("id")]
    public string? Id { get; set; }
}