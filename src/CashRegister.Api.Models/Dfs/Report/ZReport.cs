using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CashRegister.Api.Models.Dfs.Report;

[GeneratedCode("XmlSchemaClassGenerator", "2.0.711.0")]
[Serializable]
[XmlType("ZRepContent", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlRoot("ZREP", Namespace = "")]
public class ZReport
{
    /// <summary>
    /// Заголовок.
    /// </summary>
    [Required]
    [XmlElement("ZREPHEAD", Form = XmlSchemaForm.Unqualified)]
    public ZReportHeader? Header { get; set; }

    /// <summary>
    /// Підсумки реалізації.
    /// </summary>
    [XmlElement("ZREPREALIZ", Form = XmlSchemaForm.Unqualified)]
    public ZReportSalesReturnTotals? SaleTotals { get; set; }

    /// <summary>
    /// Підсумки повернення.
    /// </summary>
    [XmlElement("ZREPRETURN", Form = XmlSchemaForm.Unqualified)]
    public ZReportSalesReturnTotals? ReturnTotals { get; set; }

    /// <summary>
    /// Підсумки видачі готівки.
    /// </summary>
    [XmlElement("ZREPCASH", Form = XmlSchemaForm.Unqualified)]
    public ZReportCashOutputTotals? CashOutputTotals { get; set; }

    /// <summary>
    /// Підсумки операцій з іноземною валютою.
    /// </summary>
    [XmlElement("ZREPVAL", Form = XmlSchemaForm.Unqualified)]
    public CurrencyOperationsTotals? CurrencyOperationTotals { get; set; }

    /// <summary>
    /// Підсумки операцій для АЗС.
    /// </summary>
    [XmlElement("ZREPFUEL", Form = XmlSchemaForm.Unqualified)]
    public ZReportFuelTotals? FuelOperationsTotals { get; set; }

    /// <summary>
    /// Загальні підсумки.
    /// </summary>
    [XmlElement("ZREPBODY", Form = XmlSchemaForm.Unqualified)]
    public ZReportGeneralTotals? GeneralTotals { get; set; }

    public void WriteXml(Stream stream)
    {
        using var xmlTextWriter = new XmlTextWriter(stream, Encoding.GetEncoding(1251));
        xmlTextWriter.Formatting = Formatting.Indented;
        xmlTextWriter.Indentation = 2;
        xmlTextWriter.WriteStartDocument();
        xmlTextWriter.WriteStartElement("ZREP");
        xmlTextWriter.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
        xmlTextWriter.WriteAttributeString("xsi:noNamespaceSchemaLocation", "zrep01.xsd");
        Header?.WriteXml(xmlTextWriter);
        SaleTotals?.WriteXml(xmlTextWriter, "ZREPREALIZ");
        ReturnTotals?.WriteXml(xmlTextWriter,"ZREPRETURN");
        GeneralTotals?.WriteXml(xmlTextWriter);
        xmlTextWriter.WriteEndElement();
    }
}