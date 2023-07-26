using Newtonsoft.Json;

namespace CashRegister.Uapki.Requests;

public class Mechanism
{
    public string? Id { get; set; }

    public string? Name { get; set; }

    [JsonProperty("keyParam")]
    public string[]? KeyParameters { get; set; }

    [JsonProperty("signAlgo")]
    public string[]? SignAlgorithm { get; set; }
}