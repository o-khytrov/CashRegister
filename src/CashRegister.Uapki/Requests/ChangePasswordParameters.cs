using Newtonsoft.Json;

namespace CashRegister.Uapki.Requests;

internal class ChangePasswordParameters
{
    [JsonProperty("password")]
    public string? OldPassword { get; set; }

    [JsonProperty("newPassword")]
    public string? NewPassword { get; set; }
}