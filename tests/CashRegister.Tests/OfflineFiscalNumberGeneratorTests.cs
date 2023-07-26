using System.Text;
using CashRegister.Models.Services;
using Xunit;

namespace CashRegister.Tests;

public class OfflineFiscalNumberGeneratorTests
{
    public OfflineFiscalNumberGeneratorTests()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    }

    [Fact]
    public void GenerateFiscalNumber()
    {
        var generator = new OfflineFiscalNumberGenerator();
        var @params = new OfflineFiscalNumberParams
        {
            OfflineSeed = 179625192271939,
            DocumentDateTime = new DateTime(2020, 08, 20, 14, 23, 38),
            CashRegisterFiscalNumber = 4000002411,
            CashRegisterLocalNumber = 10,
            Sum = null,
            DocumentLocalNumber = 10,
            PreviousDocumentHash = "cdd68bb111f8993f3603f0179341571b35b73a07d5acee9b28fbfb714698e1b3"
        };
        var stringToHash = generator.CreateHashTarget(@params);
        Assert.Equal(
            "179625192271939,20082020,142338,10,4000002411,10,cdd68bb111f8993f3603f0179341571b35b73a07d5acee9b28fbfb714698e1b3",
            stringToHash);

        var controlNumber = generator.ComputeControlNumber(stringToHash);
        Assert.Equal("4758", controlNumber);
    }
}