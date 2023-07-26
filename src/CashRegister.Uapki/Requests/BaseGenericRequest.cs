using Newtonsoft.Json;

namespace CashRegister.Uapki.Requests;

internal class BaseGenericRequest<T> : BaseRequest
{
    public BaseGenericRequest(string methodName)
        : base(methodName)
    {
    }

    [JsonProperty("parameters")]
    public T? Parameters { get; set; }
}