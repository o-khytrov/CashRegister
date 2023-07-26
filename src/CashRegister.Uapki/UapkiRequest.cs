using Newtonsoft.Json;

namespace CashRegister.Uapki;

public class UapkiRequest
{
    [JsonProperty("method")]
    public string? Method { get; set; }
}