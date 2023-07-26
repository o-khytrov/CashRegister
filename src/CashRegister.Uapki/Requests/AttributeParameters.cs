using Newtonsoft.Json;

namespace CashRegister.Uapki.Requests;

public class AttributeParameters
{
    public AttributeParameters(string type, string bytesBase64)
    {
        Type = type;
        BytesBase64 = bytesBase64;
    }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("bytes")]
    public string BytesBase64 { get; set; }
}