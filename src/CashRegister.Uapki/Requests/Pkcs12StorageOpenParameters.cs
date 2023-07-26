using Newtonsoft.Json;

namespace CashRegister.Uapki.Requests;

public class Pkcs12StorageOpenParameters : IStorageOpenParameters
{
    public Pkcs12StorageOpenParameters()
    {
        Provider = "PKCS12";
        OpenParameters = new Pkcs12StorageOpenInnerParameters();
        OpenMode = StorageOpenMode.ReadOnly;
    }

    [JsonProperty("password")]
    public string? Password { get; set; }

    [JsonProperty("openParams")]
    public Pkcs12StorageOpenInnerParameters OpenParameters { get; set; }

    [JsonProperty("provider")]
    public string Provider { get; }

    [JsonProperty("storage")]
    public string? Storage { get; set; }

    [JsonProperty("mode")]
    public StorageOpenMode OpenMode { get; set; }
}