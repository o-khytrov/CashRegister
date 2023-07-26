using System.Xml;
using CashRegister.Api.Models;
using CashRegister.Api.Models.Dfs.Enums;

namespace CashRegister.Api.Services;

public class XmlCheckParser
{
    public static CheckModel Parse(string xmlString)
    {
        var xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlString);

        var checkHeadNode = xmlDoc.SelectSingleNode("/CHECK/CHECKHEAD") ?? throw new Exception("Incorrect xml data");
        var checkPayNodes = xmlDoc.SelectNodes("/CHECK/CHECKPAY/ROW") ?? throw new Exception("Incorrect xml data");
        var checkRowNodes = xmlDoc.SelectNodes("/CHECK/CHECKBODY/ROW") ?? throw new Exception("Incorrect xml data");
        var orderTaxNumNode = checkHeadNode.SelectSingleNode("ORDERTAXNUM") ?? throw new Exception("Incorrect xml data");
        var cashRegisterIdNode = checkHeadNode.SelectSingleNode("CASHREGISTERNUM") ?? throw new Exception("Incorrect xml data");
        ulong.TryParse(orderTaxNumNode.InnerText, out var orderNumber);
        var checkModel = new CheckModel
        {
            CashRegisterId = ulong.Parse(cashRegisterIdNode.InnerText),
            Number = orderNumber,
            Rows = ParseCheckRows(checkRowNodes),
            Payments = ParseCheckPayments(checkPayNodes)
        };

        return checkModel;
    }

    private static IEnumerable<CheckRow> ParseCheckRows(XmlNodeList checkRowNodes)
    {
        var rows = new List<CheckRow>();

        foreach (XmlNode rowNode in checkRowNodes)
        {
            CheckRow row = new CheckRow
            {
                ItemName = rowNode.SelectSingleNode("NAME")?.InnerText,
                RetailPrice = decimal.Parse(rowNode.SelectSingleNode("PRICE")?.InnerText ?? "0"),
                FinalPrice = decimal.Parse(rowNode.SelectSingleNode("SUBTOTAL")?.InnerText ?? "0"),
                Amount = decimal.Parse(rowNode.SelectSingleNode("AMOUNT")?.InnerText ?? "0"),
                SumDelta = decimal.Parse(rowNode.SelectSingleNode("DISCOUNTSUM")?.InnerText ?? "0"),
                Sum = decimal.Parse(rowNode.SelectSingleNode("COST")?.InnerText ?? "0"),
                TaxSum = 0,
                Tax = null,
                UnitCode = int.Parse(rowNode.SelectSingleNode("UNITCD")?.InnerText ?? "0")
            };

            rows.Add(row);
        }

        return rows;
    }

    private static IEnumerable<CheckPayment> ParseCheckPayments(XmlNodeList checkPayNodes)
    {
        var payments = new List<CheckPayment>();

        foreach (XmlNode payNode in checkPayNodes)
        {
            payments.Add(new CheckPayment
            {
                Form = (EPaymentForm) int.Parse(payNode.SelectSingleNode("PAYFORMCD")?.InnerText ?? "0"),
                Sum = decimal.Parse(payNode.SelectSingleNode("SUM")?.InnerText ?? "0")
            });
        }

        return payments;
    }
}