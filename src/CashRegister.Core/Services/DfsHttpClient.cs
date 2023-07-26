using System.IO.Compression;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using CashRegister.Api.Models.Dfs;
using CashRegister.Models.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CashRegister.Models.Services;

public class DfsHttpClient : HttpClient
{
    private readonly DfsOptions _dfsOptions;

    public DfsHttpClient(IOptions<DfsOptions> options)
        : base(new HttpClientHandler
        {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
        })
    {
        _dfsOptions = options.Value;
        Timeout = TimeSpan.FromSeconds(30);
    }

    public async Task<TResponse> PostUnsignedCommand<TRequest, TResponse>(TRequest sendData)
    {
        var requestData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(sendData));
        var compressedData = await CompressDate(requestData);
        var url = _dfsOptions.ApiCmd + $"?randomseed={DateTime.Now.Ticks}";
        var responseMessage = await SendData(compressedData, url);

        if (!responseMessage.IsSuccessStatusCode)
        {
            var error = await responseMessage.Content.ReadAsStringAsync();
            throw new DfsException(error);
        }

        var responseString = await responseMessage.Content.ReadAsStringAsync();
        if (string.IsNullOrWhiteSpace(responseString)) throw new DfsException("empty response from Dfs");

        return JsonConvert.DeserializeObject<TResponse>(responseString);
    }

    public async Task<byte[]> ReadCommandAsBytes<TRequest, TResponse>(TRequest sendData, UserKeyInfo keyInfo)
    {
        var responseMessage = await SendSignedCommand<TRequest, TResponse>(sendData, keyInfo);

        if (!responseMessage.IsSuccessStatusCode)
        {
            var error = await responseMessage.Content.ReadAsStringAsync();
            throw new DfsException(error);
        }

        var responseBytes = await responseMessage.Content.ReadAsByteArrayAsync();
        return SignatureReader.DecryptSignedData(responseBytes);
    }

    public async Task<TResponse> PostSignedCommand<TRequest, TResponse>(TRequest sendData, UserKeyInfo keyInfo)
    {
        var responseMessage = await SendSignedCommand<TRequest, TResponse>(sendData, keyInfo);

        if (!responseMessage.IsSuccessStatusCode)
        {
            var error = await responseMessage.Content.ReadAsStringAsync();
            throw new DfsException(error);
        }

        var responseString = await responseMessage.Content.ReadAsStringAsync();
        if (string.IsNullOrWhiteSpace(responseString)) throw new DfsException("empty response from Dfs");

        return JsonConvert.DeserializeObject<TResponse>(responseString);
    }

    private async Task<HttpResponseMessage> SendSignedCommand<TRequest, TResponse>(TRequest sendData,
        UserKeyInfo keyInfo)
    {
        var requestData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(sendData));
        var signData = UapkiService.SignData(requestData, keyInfo.KeyDirectory, keyInfo.Password);
        var compressedData = await CompressDate(signData);
        var url = _dfsOptions.ApiCmd + $"?randomseed={DateTime.Now.Ticks}";
        var responseMessage = await SendData(compressedData, url);
        return responseMessage;
    }

    public async Task<byte[]> PostXml(byte[] requestData, UserKeyInfo userKeyInfo)
    {
        var signData = UapkiService.SignData(requestData, userKeyInfo.KeyDirectory, userKeyInfo.Password);
        var ulr = _dfsOptions.ApiDoc + $"?randomseed={DateTime.Now.Ticks}";

        var compressedData = await CompressDate(signData);
        var responseMessage = await SendData(compressedData, ulr);
        if (!responseMessage.IsSuccessStatusCode)
        {
            var error = await responseMessage.Content.ReadAsStringAsync();
            throw new DfsException(error);
        }

        return await responseMessage.Content.ReadAsByteArrayAsync();
    }

    private async Task<HttpResponseMessage> SendData(byte[] compressedData, string url)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, url);
        var outStream = new MemoryStream(compressedData);
        var streamContent = new StreamContent(outStream);
        streamContent.Headers.Add("Content-Encoding", "gzip");
        streamContent.Headers.ContentLength = outStream.Length;
        request.Content = streamContent;
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        var responseMessage = await SendAsync(request);
        return responseMessage;
    }

    private static async Task<byte[]> CompressDate(byte[] data)
    {
        await using var memoryStream = new MemoryStream();
        await using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Compress))
        {
            await gzipStream.WriteAsync(data, 0, data.Length);
        }

        return memoryStream.ToArray();
    }
}