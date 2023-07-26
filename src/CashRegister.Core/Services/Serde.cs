using System.Text;
using Newtonsoft.Json;

namespace CashRegister.Models.Services;

public static class Serde
{
    private static readonly JsonSerializerSettings DefaultSerializerSettings = new() { TypeNameHandling = TypeNameHandling.All };

    public static string Serialize(this object obj, JsonSerializerSettings? options = null)
        => JsonConvert.SerializeObject(obj, Formatting.None, options ?? DefaultSerializerSettings);

    public static byte[] Serialize(this string rawObject)
        => Encoding.UTF8.GetBytes(rawObject);

    public static T? Deserialize<T>(this byte[] bytes, JsonSerializerSettings? options = null)
        => Deserialize<T>(Encoding.UTF8.GetString(bytes), options ?? DefaultSerializerSettings);

    public static T? Deserialize<T>(this string rawObject, JsonSerializerSettings? options = null) =>
        JsonConvert.DeserializeObject<T>(rawObject, options ?? DefaultSerializerSettings);
}
