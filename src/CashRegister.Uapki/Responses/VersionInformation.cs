using CashRegister.Uapki.Requests;
using Newtonsoft.Json;

namespace CashRegister.Uapki.Responses;

public class VersionInformation
{
    public string? Name { get; set; }

    public string? Version { get; set; }
}

public class TspInformation
{
    [JsonProperty("url")]
    public string? Url { get; set; }

    [JsonProperty("policyId")]
    public string? PolicyId { get; set; }
}

public class Storage
{
    public string? Id { get; set; }

    public string? ProviderId { get; set; }

    public string? Manufacturer { get; set; }

    public string? Description { get; set; }

    public string? Serial { get; set; }

    public string? Label { get; set; }

    public StorageInfo? StorageInfo { get; set; }

    public List<KeyInfo>? Keys { get; set; }

    public List<Mechanism>? Mechanisms { get; set; }

    public bool UserPresense { get; set; }

    public IStorageOpenParameters? StorageOpenParameters { get; set; }
}

public class SignatureResult
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("bytes")]
    public string? BytesBase64 { get; set; }
}

public class SigningResponse
{
    [JsonProperty("signatures")]
    public List<SignatureResult>? Signatures { get; set; }
}

internal class SelectedKeyInfo
{
    [JsonProperty("signAlgo")]
    public List<string>? SigningAlgorithms { get; set; }

    [JsonProperty("certId")]
    public string? CertificateId { get; set; }

    [JsonProperty("cert")]
    public string? CertificateBase64 { get; set; }
}

public class CertificateStorageRecord
{
    [JsonProperty("certId")]
    public string? Id { get; set; }

    [JsonProperty("isUnique")]
    public bool IsUnique { get; set; }
}

internal class AddCertificateResult
{
    [JsonProperty("added")]
    public List<CertificateStorageRecord>? Certificates { get; set; }
}