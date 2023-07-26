using Newtonsoft.Json;

namespace CashRegister.Uapki.Requests;

public class Pkcs12StorageOpenInnerParameters
{
    public Pkcs12StorageOpenInnerParameters()
    {
        Cipher = "1.2.804.2.1.1.1.1.1.1.3";
        KeyDerivationFunction = "1.2.804.2.1.1.1.1.1.2";
        MacAlgorithm = "1.2.804.2.1.1.1.1.2.1";
        KdfIterations = 10000;
    }

    [JsonProperty("bagCipher")]
    public string Cipher { get; set; }

    [JsonProperty("bagKdf")]
    public string KeyDerivationFunction { get; set; }

    [JsonProperty("iterations")]
    public int KdfIterations { get; set; }

    [JsonProperty("macAlgo")]
    public string MacAlgorithm { get; set; }
}