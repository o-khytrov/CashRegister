using Newtonsoft.Json;

namespace CashRegister.Uapki.Requests;

internal class StorageInfoParameters
{
    [JsonProperty("provider")]
    public string? Provider { get; set; }

    [JsonProperty("storage")]
    public string? Storage { get; set; }
}