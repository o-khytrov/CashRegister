using System.Net;
using CashRegister.Api.Models;
using CashRegister.Api.Models.Dfs;
using Newtonsoft.Json;

namespace CashRegister.Api.Services;

public class ApiResponseWrapperMiddleware
{
    private readonly RequestDelegate _next;

    public ApiResponseWrapperMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path.HasValue &&
            context.Request.Path.Value.Contains("print_check"))
        {
            await _next.Invoke(context);
            return;
        }

        await using var responseStream = new MemoryStream();
        var originalResponseStream = context.Response.Body;

        context.Response.Body = responseStream;
        context.Response.ContentType = "application/json";

        ApiResponse? apiResponse = null;

        try
        {
            await _next.Invoke(context);

            var rawResponseBody = await GetResponse(context.Response.Body);
            var body = JsonConvert.DeserializeObject(rawResponseBody);

            apiResponse = ApiResponse.Create(context.Response.StatusCode, body);
        }
        catch (Exception ex)
        {
            apiResponse = CreateErrorResponse(ex);
        }
        finally
        {
            context.Response.StatusCode = apiResponse!.StatusCode;

            var json = JsonConvert.SerializeObject(apiResponse);
            await context.Response.WriteAsync(json);

            context.Response.ContentLength = context.Response.Body.Length;

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            await context.Response.Body.CopyToAsync(originalResponseStream);

            context.Response.Body = originalResponseStream;
        }
    }

    private static ApiResponse CreateErrorResponse(Exception exception)
    {
        if (exception is ApiException apiException)
            return ApiResponse.Create((int) apiException.StatusCode, error: apiException.Message);
#if !DEBUG
            var error = "An unhandled error occurred. Please contact the system administrator.";
            string? stackTrace = null;
#else
        var error = exception.GetBaseException().Message;
        var stackTrace = exception.StackTrace;
#endif
        return ApiResponse.Create((int) HttpStatusCode.InternalServerError, error: error, details: stackTrace);
    }

    private static async Task<string> GetResponse(Stream stream)
    {
        stream.Seek(0, SeekOrigin.Begin);
        var plainBodyText = await new StreamReader(stream).ReadToEndAsync();
        stream.Seek(0, SeekOrigin.Begin);

        return plainBodyText;
    }
}