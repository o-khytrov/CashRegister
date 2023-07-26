using System.Text.Json.Serialization;

namespace CashRegister.Api.Models;

public class ApiResponse : ApiResponse<object>
{
    private ApiResponse(
        int statusCode,
        object? result = null,
        string? error = null,
        string? details = null)
        : base(statusCode, result, error, details)
    {
    }

    public static ApiResponse Create(
        int statusCode,
        object? result = null,
        string? error = null,
        string? details = null)
    {
        return new ApiResponse(statusCode, result, error, details);
    }
}

public class ApiResponse<T>
    where T : class
{
    public ApiResponse()
    {
    }

    [JsonConstructor]
    protected ApiResponse(
        int statusCode,
        T? result = null,
        string? error = null,
        string? details = null)
    {
        StatusCode = statusCode;
        Result = result;
        Error = error;
        Details = details;
    }

    public int StatusCode { get; set; }

    public T? Result { get; set; }

    public string? Error { get; set; }

    public string? Details { get; set; }
}