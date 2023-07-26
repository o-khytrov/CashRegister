using System.Runtime.InteropServices;
using System.Text;
using CashRegister.Uapki.Requests;
using CashRegister.Uapki.Responses;
using Newtonsoft.Json;

namespace CashRegister.Uapki;

public static partial class UapkiLibrary
{
    public static VersionInformation Version()
    {
        var versionRequest = new VersionRequest();
        return Process<VersionInformation>(versionRequest);
    }

    public static InitializationInformation Init(
        string certCachePath = "certs/",
        string crlCachePath = "certs/crls/",
        string defaultTspUrl = "http://acskidd.gov.ua/services/tsp/",
        List<byte[]>? trustedCerts = null,
        bool offline = false)
    {
        EnsureDirectoreisExist(certCachePath);
        EnsureDirectoreisExist(crlCachePath);

        var initRequest = new InitializationGenericRequest
        {
            Parameters = new InitializationParameters
            {
                CmProviders = new CmProviders(string.Empty),
                CertificateCache = new CertificateCache
                {
                    Path = certCachePath,
                    TrustedCertificates = trustedCerts?.Select(s => Convert.ToBase64String(s))
                },
                CrlCache = new CrlCache
                {
                    Path = crlCachePath
                },
                TspAddress = new TspAddress
                {
                    Url = defaultTspUrl
                },
                Offline = offline
            }
        };

        var result = Process<InitializationInformation>(initRequest);
        return result;
    }

    private static void EnsureDirectoreisExist(string certCachePath)
    {
        if (!Directory.Exists(certCachePath))
        {
            Directory.CreateDirectory(certCachePath);
        }
    }

    public static void DeInit()
    {
        Process<object>(new DeInitRequest());
    }

    [DllImport("uapki", EntryPoint = "json_free", CallingConvention = CallingConvention.Cdecl)]
    private static extern void JsonFree(IntPtr response);

    [DllImport("uapki", EntryPoint = "process", CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr Process([MarshalAs(UnmanagedType.LPUTF8Str)] string request);

    private static unsafe TResponse Process<TResponse>(BaseRequest request)
    {
        var json = request.ToJson();

        var resultPtr = (byte*) Process(json);
        string? result;

        try
        {
            var length = 0;
            for (var i = resultPtr; *i != 0; i++) length++;

            result = Encoding.UTF8.GetString(resultPtr, length);
        }
        finally
        {
            JsonFree((IntPtr) resultPtr);
        }

        if (string.IsNullOrWhiteSpace(result)) throw new UapkiException(1, "Unknown error");

        var resultModel = JsonConvert.DeserializeObject<CommonResponse<TResponse>>(result) ??
                          throw new UapkiException(1, "Unknown error");

        if (resultModel is not { IsSuccess: false })
        {
            var retVal = resultModel.Result ?? throw new UapkiException(1, "Unknown error");
            return retVal;
        }

        var ex = new UapkiException(resultModel.ErrorCode, resultModel.Error);
        throw ex;
    }
}