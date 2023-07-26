using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using CashRegister.Api.Models.Dfs.Enums;

namespace CashRegister.Api.Models.Dfs.Check;

[GeneratedCode("XmlSchemaClassGenerator", "2.0.711.0")]
[Serializable]
[XmlType("CheckContent")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlRoot("CHECK")]
public class Check
{
    public Check()
    {
    }

    public Check(CheckHead checkHead)
    {
        CheckHead = checkHead;
    }

    /// <summary>
    /// Заголовок.
    /// </summary>
    [Required]
    [XmlElement("CHECKHEAD", Form = XmlSchemaForm.Unqualified)]
    public CheckHead CheckHead { get; set; }

    /// <summary>
    /// Підсумок по чеку.
    /// </summary>
    [XmlElement("CHECKTOTAL", Form = XmlSchemaForm.Unqualified)]
    public CheckTotal? CheckTotal { get; set; }

    /// <summary>
    /// Підсумки по формам оплати.
    /// </summary>
    [XmlArray("CHECKPAY", Form = XmlSchemaForm.Unqualified)]
    [XmlArrayItem("ROW", Form = XmlSchemaForm.Unqualified)]
    public List<CheckPaymentRow>? CheckPaymentRows { get; set; }

    /// <summary>
    /// Податки/Збори.
    /// </summary>
    [XmlArray("CHECKTAX", Form = XmlSchemaForm.Unqualified)]
    [XmlArrayItem("ROW", Form = XmlSchemaForm.Unqualified)]
    public List<CheckTaxRow>? CheckTax { get; set; }

    /// <summary>
    /// Реквізити програмно-технічного комплексу самообслуговування (ПТКС).
    /// </summary>
    [XmlElement("CHECKPTKS", Form = XmlSchemaForm.Unqualified)]
    public SelfServiceComplexProperties? Checkptks { get; set; }

    /// <summary>
    /// Продажі.
    /// </summary>
    [XmlArray("CHECKBODY", Form = XmlSchemaForm.Unqualified)]
    [XmlArrayItem("ROW", Form = XmlSchemaForm.Unqualified)]
    public List<CheckBodyRow>? BodyRows { get; set; }

    public void WriteXml(Stream stream)
    {
        using var wr = new XmlTextWriter(stream, Encoding.GetEncoding(1251));
        wr.Formatting = Formatting.Indented;
        wr.Indentation = 2;
        wr.WriteStartDocument();
        wr.WriteStartElement("CHECK");
        wr.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
        wr.WriteAttributeString("xsi:noNamespaceSchemaLocation", "check01.xsd");
        CheckHead.WriteXml(wr);

        if (CheckHead.DocType == EDfsCheckDocumentType.SaleGoods)
        {
            CheckTotal?.WriteXml(wr);
            if (CheckHead.DocSubType == EDfsCheckDocumentSubType.CheckGoods ||
                CheckHead.DocSubType == EDfsCheckDocumentSubType.CheckReturn)
            {
                WritePayments(wr);
                WriteBody(wr);
            }
        }

        wr.WriteEndDocument();
    }

    private void WritePayments(XmlTextWriter wr)
    {
        wr.WriteStartElement("CHECKPAY");
        foreach (var payment in CheckPaymentRows)
        {
            payment.WriteXml(wr);
        }

        wr.WriteEndElement();
    }

    private void WriteBody(XmlTextWriter wr)
    {
        wr.WriteStartElement("CHECKBODY");
        foreach (var bodyRow in BodyRows)
        {
            bodyRow.WriteXml(wr);
        }

        wr.WriteEndElement();
    }
}