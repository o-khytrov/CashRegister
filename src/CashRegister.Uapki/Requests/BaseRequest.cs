using Newtonsoft.Json;

namespace CashRegister.Uapki.Requests;

internal class BaseRequest
{
    private static readonly JsonSerializerSettings _serializationSettings = new()
    {
        NullValueHandling = NullValueHandling.Ignore
    };

    public BaseRequest(string methodName)
    {
        Method = methodName;
    }

    [JsonProperty("method")]
    public string Method { get; set; }

    public string ToJson()
    {
        Formatting format;
#if DEBUG
        format = Formatting.Indented;
#else
            format = Formatting.None;
#endif
        return JsonConvert.SerializeObject(this, format, _serializationSettings);
    }
}