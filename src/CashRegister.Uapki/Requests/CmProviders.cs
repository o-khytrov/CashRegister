using Newtonsoft.Json;

namespace CashRegister.Uapki.Requests;

internal class CmProviders
{
    public CmProviders(string dir)
    {
        Directory = dir;
        AllowedProviders = new[]
        {
            new AllowedProvider
            {
                Library = "cm-pkcs12"
            }
        };
    }

    [JsonProperty("dir")]
    public string Directory { get; set; }

    [JsonProperty("allowedProviders")]
    public IEnumerable<AllowedProvider> AllowedProviders { get; set; }
}