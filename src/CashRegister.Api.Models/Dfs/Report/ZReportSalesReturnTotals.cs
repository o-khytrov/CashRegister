using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using CashRegister.Api.Models.Dfs.Extensions;

namespace CashRegister.Api.Models.Dfs.Report;

/// <summary>
/// Підсумки реалізації і повернення.
/// </summary>
[GeneratedCode("XmlSchemaClassGenerator", "2.0.711.0")]
[Serializable]
[XmlType("ZPay", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class ZReportSalesReturnTotals
{
    /// <summary>
    /// Загальна сума (15.2 цифри).
    /// </summary>
    [RegularExpression("\\-{0,1}[0-9]+\\.[0-9]{2}")]
    [Required]
    [XmlElement("SUM", Form = XmlSchemaForm.Unqualified)]
    public decimal Sum { get; set; }

    /// <summary>
    /// Загальна сума коштів, виданих клієнту ломбарда (15.2 цифри).
    /// </summary>
    [RegularExpression("\\-{0,1}[0-9]+\\.[0-9]{2}")]
    [XmlElement("PWNSUMISSUED", Form = XmlSchemaForm.Unqualified)]
    public decimal PawnShopSumIssued { get; set; }

    /// <summary>
    /// Загальна сума коштів, одержаних від клієнта ломбарда (15.2 цифри).
    /// </summary>
    [RegularExpression("\\-{0,1}[0-9]+\\.[0-9]{2}")]
    [XmlElement("PWNSUMRECEIVED", Form = XmlSchemaForm.Unqualified)]
    public decimal PawnShopSumReceived { get; set; }

    /// <summary>
    /// Заокруглення (15.2 цифри) (наприклад, 0.71).
    /// </summary>
    [RegularExpression("\\-{0,1}[0-9]+\\.[0-9]{2}")]
    [XmlElement("RNDSUM", Form = XmlSchemaForm.Unqualified)]
    public decimal RoundSum { get; set; }

    /// <summary>
    /// Загальна сума без заокруглення (15.2 цифри) (наприклад, 1000.71).
    /// </summary>
    [RegularExpression("\\-{0,1}[0-9]+\\.[0-9]{2}")]
    [XmlElement("NORNDSUM", Form = XmlSchemaForm.Unqualified)]
    public decimal NoRoundSum { get; set; }

    /// <summary>
    /// Кількість чеків (числовий).
    /// </summary>
    [Required]
    [XmlElement("ORDERSCNT", Form = XmlSchemaForm.Unqualified)]
    public int OrdersCount { get; set; }

    /// <summary>
    /// Кількість операцій переказу коштів (числовий).
    /// </summary>
    [XmlElement("TOTALCURRENCYCOST", Form = XmlSchemaForm.Unqualified)]
    public int TotalCurrencyCost { get; set; }

    /// <summary>
    /// Загальна сума переказів коштів (15.2 цифри).
    /// </summary>
    [RegularExpression("\\-{0,1}[0-9]+\\.[0-9]{2}")]
    [XmlElement("TOTALCURRENCYSUM", Form = XmlSchemaForm.Unqualified)]
    public decimal TotalCurrencySum { get; set; }

    /// <summary>
    /// Загальна сума комісії від переказів коштів (15.2 цифри).
    /// </summary>
    [RegularExpression("\\-{0,1}[0-9]+\\.[0-9]{2}")]
    [XmlElement("TOTALCURRENCYCOMMISSION", Form = XmlSchemaForm.Unqualified)]
    public decimal TotalCurrencyCommission { get; set; }

    /// <summary>
    /// Підсумки по формам оплати.
    /// </summary>
    [XmlArray("PAYFORMS", Form = XmlSchemaForm.Unqualified)]
    [XmlArrayItem("ROW", Form = XmlSchemaForm.Unqualified)]
    public List<PaymentFormsTotals>? PaymentForms { get; set; }

    /// <summary>
    /// Податки/Збори.
    /// </summary>
    [XmlArray("TAXES", Form = XmlSchemaForm.Unqualified)]
    [XmlArrayItem("ROW", Form = XmlSchemaForm.Unqualified)]
    public List<TaxTotals>? Taxes { get; set; }

    public void WriteXml(XmlTextWriter xmlWriter, string elementName)
    {
        xmlWriter.WriteStartElement(elementName);
        xmlWriter.WriteElement("SUM", Sum.ToString("0.00"));
        xmlWriter.WriteElement("ORDERSCNT", OrdersCount);
        if (PaymentForms is not null)
        {
            WritePaymentFormsTotals(xmlWriter);
        }

        xmlWriter.WriteEndElement();
    }

    private void WritePaymentFormsTotals(XmlTextWriter xmlWriter)
    {
        xmlWriter.WriteStartElement("PAYFORMS");

        foreach (var paymentForm in PaymentForms)
        {
            xmlWriter.WriteStartElement("ROW");
            xmlWriter.WriteAttributeString("ROWNUM", paymentForm.RowNumber.ToString());
            xmlWriter.WriteElement("PAYFORMCD", (int) paymentForm.PaymentFormCode);
            xmlWriter.WriteElement("PAYFORMNM", paymentForm.PaymentFormName);
            xmlWriter.WriteElementD2NN("SUM", paymentForm.Sum);
            xmlWriter.WriteEndElement();
        }

        xmlWriter.WriteEndElement();
    }
}