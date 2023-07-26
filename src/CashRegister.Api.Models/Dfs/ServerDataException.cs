using System.Runtime.Serialization;

namespace CashRegister.Api.Models.Dfs;

[Serializable]
public class ServerDataException : Exception
{
    public ServerDataException(ServerErrorCode code, string message)
        : base(message)
    {
        Code = code;
    }

    public ServerDataException(ServerErrorCode code, string message, Exception innerException)
        : base(message, innerException)
    {
        Code = code;
    }

    protected ServerDataException(
        SerializationInfo serializationInfo,
        StreamingContext streamingContext)
        : base(serializationInfo, streamingContext)
    {
    }

    public ServerErrorCode Code { get; }
}