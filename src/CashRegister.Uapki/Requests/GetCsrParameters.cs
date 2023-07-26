using Newtonsoft.Json;

namespace CashRegister.Uapki.Requests;

internal class GetCsrParameters
{
    [JsonProperty("signAlgo")]
    public string? SignAlgorithm { get; set; }
}