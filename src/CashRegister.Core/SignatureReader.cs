using System.Formats.Asn1;
using System.Text;

namespace CashRegister.Models;

public static class SignatureReader
{
    public static string GetTicketXmlString(byte[] signedData)
    {
        var ticketBytes = DecryptSignedData(signedData);
        var ticketBytesUtf8 = Encoding.Convert(Encoding.GetEncoding("windows-1251"), Encoding.UTF8, ticketBytes);
        return Encoding.UTF8.GetString(ticketBytesUtf8);
    }

    public static byte[] DecryptSignedData(byte[] signedData)
    {
        try
        {
            var reader = new AsnReader(signedData, AsnEncodingRules.BER);
            var root = reader.ReadSequence();
            _ = root.ReadObjectIdentifier();
            var body = root.ReadEncodedValue();
            var bodyReader = new AsnReader(body, AsnEncodingRules.BER);
            var contentInfoSequence = bodyReader.ReadSequence(new Asn1Tag(TagClass.ContextSpecific, 0));
            var encodedContent = contentInfoSequence.ReadEncodedValue();
            var encodedContentReader = new AsnReader(encodedContent, AsnEncodingRules.BER);
            var encodedContentSequence = encodedContentReader.ReadSequence();
            _ = encodedContentSequence.ReadInteger();

            _ = encodedContentSequence.ReadSetOf();
            var unsignedDataSequence = encodedContentSequence.ReadSequence();
            _ = unsignedDataSequence.ReadObjectIdentifier();
            var unsignedDataEncodedValue = unsignedDataSequence.ReadEncodedValue();
            var unsignedDataReader = new AsnReader(unsignedDataEncodedValue, AsnEncodingRules.BER);
            return unsignedDataReader.ReadOctetString(new Asn1Tag(TagClass.ContextSpecific, 0));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}