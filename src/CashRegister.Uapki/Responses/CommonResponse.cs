using System.Text.Json.Serialization;

namespace CashRegister.Uapki.Responses;

public class CommonResponse<T>
{
    [JsonConstructor]
    public CommonResponse(int errorCode, string? error, string? method, T result)
    {
        ErrorCode = errorCode;
        Error = error;
        Method = method;
        Result = result;
    }

    public int ErrorCode { get; set; }

    public string? Error { get; set; }

    public string? Method { get; set; }

    public T Result { get; set; }

    public bool IsSuccess => ErrorCode == 0;
}