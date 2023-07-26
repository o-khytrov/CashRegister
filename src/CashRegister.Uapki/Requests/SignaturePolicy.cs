using Newtonsoft.Json;

namespace CashRegister.Uapki.Requests;

public class SignaturePolicy
{
    [JsonProperty("sigPolicyId")]
    public string? PolicyId { get; set; }

    public static SignaturePolicy Default => new()
    {
        PolicyId = "1.2.804.2.1.1.1.2.1"
    };
}