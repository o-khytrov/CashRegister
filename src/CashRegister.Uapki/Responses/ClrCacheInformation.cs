using Newtonsoft.Json;

namespace CashRegister.Uapki.Responses;

public class ClrCacheInformation
{
    [JsonProperty("countCrls")]
    public int Count { get; set; }
}