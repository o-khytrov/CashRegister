using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CashRegister.Uapki.Requests;

[JsonConverter(typeof(StringEnumConverter))]
public enum SignatureFormat
{
    [EnumMember(Value = "RAW")]
    Raw,

    [EnumMember(Value = "CMS")]
    Cms,

    [EnumMember(Value = "CAdES-T")]
    CadesT,

    [EnumMember(Value = "CAdES-BES")]
    CadesBes
}