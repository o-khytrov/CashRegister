using System.Runtime.Serialization;

namespace CashRegister.Uapki;

[Serializable]
public class UapkiException : Exception
{
    public UapkiException()
    {
    }

    public UapkiException(int error)
        : base("Помилка криптобібліотеки (код помилки " + error.ToString("X") + ")")
    {
    }

    public UapkiException(int error, Exception inner)
        : base("Помилка криптобібліотеки (код помилки " + error.ToString("X") + ")", inner)
    {
    }

    public UapkiException(int error, string? message)
        : base($"Помилка криптобібліотеки (код помилки {error}) {message}")
    {
    }

    protected UapkiException(SerializationInfo serializationInfo, StreamingContext streamingContext)
    {
        throw new NotImplementedException();
    }

    public int ErrorCode { get; set; }
}