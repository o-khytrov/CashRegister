using System.Globalization;
using System.Xml;

namespace CashRegister.Api.Models.Dfs.Extensions;

public static class XmlWriterExtension
{
    public static void WriteElement<T>(this XmlWriter wr, string name, T val)
    {
        var str = val?.ToString();
        if (string.IsNullOrWhiteSpace(str)) return;

        wr.WriteElementString(name, str);
    }

    public static void WriteElement(this XmlWriter wr, string name, Guid val)
    {
        wr.WriteElement(name, val.ToString("D").ToUpper());
    }

    public static void WriteElementD2(this XmlWriter wr, string name, decimal val)
    {
        wr.WriteElement(name, val.ToString("#0.00", CultureInfo.InvariantCulture));
    }

    public static void WriteElementNn<T>(this XmlWriter wr, string name, T? val)
    {
        var str = val?.ToString();
        if (string.IsNullOrWhiteSpace(str)) return;

        wr.WriteElementString(name, str);
    }

    public static void WriteElementNN<T>(this XmlWriter wr, string name, T? val) where T : struct
    {
        wr.WriteElementNn(name, (object) val?.ToString());
    }

    public static void WriteElementD2NN(this XmlWriter wr, string name, decimal? val)
    {
        if (!val.HasValue)
        {
            return;
        }

        wr.WriteElement(name, val.Value.ToString("#0.00", CultureInfo.InvariantCulture));
    }

    public static void WriteElementD3NN(this XmlWriter wr, string name, decimal? val)
    {
        if (!val.HasValue)
        {
            return;
        }

        wr.WriteElement(name, val.Value.ToString("#0.000", CultureInfo.InvariantCulture));
    }
}