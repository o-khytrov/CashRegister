using System.Text;
using System.Xml.Serialization;
using CashRegister.Api.Models.Dfs.Ticket;

namespace CashRegister.Models;

public static class TicketContentExtensions
{
    public static TicketContent? FromXmlString(string xml)
    {
        var serializer = new XmlSerializer(typeof(TicketContent));
        using TextReader reader = new StringReader(xml);
        return serializer.Deserialize(reader) as TicketContent;
    }

    public static TicketContent? FromBytes(byte[] signedData)
    {
        var xml = SignatureReader.GetTicketXmlString(signedData);
        return FromXmlString(xml);
    }
}