using System.Text;
using System.Text.RegularExpressions;

namespace CashRegister.Models.Services;

public class OfflineFiscalNumberGenerator
{
    private Regex _regex = new("\\s+", RegexOptions.Compiled | RegexOptions.Singleline);

    public string GenerateFiscalNumber(OfflineFiscalNumberParams @params)
    {
        var hashTarget = CreateHashTarget(@params);
        var controlNumber = ComputeControlNumber(hashTarget);
        return $"{@params.OfflineSessionId}{@params.OfflineSessionDocumentNumber}{controlNumber}";
    }

    public string ComputeControlNumber(string target)
    {
        var bytes = Encoding.ASCII.GetBytes(_regex.Replace(target, string.Empty));
        using var crc32 = new Crc32();
        crc32.Initialize();
        crc32.ComputeHash(bytes);
        int controlNumber = (int) (BitConverter.ToUInt32(crc32.Hash, 0) % Crc32.ControlNumberDivisor);
        if (controlNumber == 0)
            controlNumber = 1;
        return controlNumber.ToString();
    }

    public string CreateHashTarget(OfflineFiscalNumberParams @params)
    {
        var paramsList = new List<string>()
        {
            @params.OfflineSeed.ToString(),
            @params.DocumentDateTime.ToString("ddMMyyyy"),
            @params.DocumentDateTime.ToString("HHmmss"),
            @params.CashRegisterLocalNumber.ToString(),
            @params.CashRegisterFiscalNumber.ToString(),
            @params.DocumentLocalNumber.ToString(),
        };
        if (@params.Sum.HasValue)
        {
            paramsList.Add(@params.Sum?.ToString("#.00"));
        }

        if (!string.IsNullOrWhiteSpace(@params.PreviousDocumentHash))
        {
            paramsList.Add(@params.PreviousDocumentHash);
        }

        return string.Join(",", paramsList);
    }
}