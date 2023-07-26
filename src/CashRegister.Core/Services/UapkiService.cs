using System.Security.Cryptography.X509Certificates;
using CashRegister.Api.Models.Dfs;
using CashRegister.Uapki;
using CashRegister.Uapki.Requests;

namespace CashRegister.Models.Services;

public static class UapkiService
{
    private static readonly Dictionary<string, KeyInfo> OpenKeys = new();

    private static bool _isInitialized;

    public static byte[] SignData(byte[] data, string keysDirectory, string keyPassword)
    {
        if (!_isInitialized)
        {
            InitUapki();
            _isInitialized = true;
        }

        KeyInfo key;
        if (OpenKeys.ContainsKey(keysDirectory))
        {
            key = OpenKeys[keysDirectory];
        }
        else
        {
            var keys = OpenKeyStorage(keysDirectory, keyPassword);
            key = keys.First();
            OpenKeys.Add(keysDirectory, key);
        }

        UapkiLibrary.SelectKey(key);

        var signedData = UapkiLibrary.Sign(new Sign
        {
            SignParameters = new SignParameters
            {
                Format = SignatureFormat.CadesBes,
                Algorithm = "1.2.804.2.1.1.1.1.3.1.1",
                IsDataDetached = false,
                NeedIncludeCertificate = true
            },
            DataParameters = new List<DataParameters>
            {
                new() { Id = "doc-0", BytesBase64 = Convert.ToBase64String(data) }
            }
        });
        return Convert.FromBase64String(signedData.First().BytesBase64);
    }

    private static IEnumerable<KeyInfo> OpenKeyStorage(string keysDirectory, string keyPassword)
    {
        var keyFile = Directory.EnumerateFiles(keysDirectory, "key-6.dat").FirstOrDefault();
        if (string.IsNullOrWhiteSpace(keyFile))
        {
            throw new NotFoundException("Key not found on server");
        }

        var openStorage = UapkiLibrary.OpenStorage(new Pkcs12StorageOpenParameters
            { Storage = keyFile, Password = keyPassword });
        var certs = new List<X509Certificate>();
        foreach (var file in Directory.GetFiles(keysDirectory, "*.cer"))
            try
            {
                var x509Certificate = X509Certificate.CreateFromCertFile(file);
                certs.Add(x509Certificate);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        UapkiLibrary.AddCertificates(certs.Select(x => x.GetRawCertData()).ToArray(), true);
        return UapkiLibrary.StorageKeysList();
    }

    private static void InitUapki()
    {
        var appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var certCachePath = Path.Combine(appDataDir, "CashRegister", "certs/");
        var clrCachePath = Path.Combine(appDataDir, "CashRegister", "certs/crls/");

        UapkiLibrary.Init(certCachePath, clrCachePath);
        UapkiLibrary.Version();
    }
}