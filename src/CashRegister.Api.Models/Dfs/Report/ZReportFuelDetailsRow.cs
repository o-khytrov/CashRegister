using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CashRegister.Api.Models.Dfs.Report;

/// <summary>
/// Підсумки по видам пального
/// </summary>
[GeneratedCode("XmlSchemaClassGenerator", "2.0.711.0")]
[Serializable]
[XmlType("TROWSFUELDETAILS", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class ZReportFuelDetailsRow
{
    /// <summary>
    /// Найменування товару (пального) (текст).
    /// </summary>
    [Required]
    [XmlElement("NAME", Form = XmlSchemaForm.Unqualified)]
    public string? FuelName { get; set; }

    /// <summary>
    /// Обсяг прийнятого пального у мілілітрах (15.2 цифри).
    /// </summary>
    [XmlElement("ACCEPTED", Form = XmlSchemaForm.Unqualified)]
    public decimal AcceptedVolume { get; set; }

    /// <summary>
    /// Обсяг відпущеного пального у мілілітрах (15.2 цифри)
    /// </summary>
    [XmlElement("REALIZVOL", Form = XmlSchemaForm.Unqualified)]
    public decimal IssuedVolume { get; set; }

    /// <summary>
    /// Обсяг пального, відпущеного в процесі повірки паливно-роздавальної колонки,  у мілілітрах (15.2 цифри).
    /// </summary>
    [XmlElement("REALIZPRK", Form = XmlSchemaForm.Unqualified)]
    public decimal REALIZPRK { get; set; }

    /// <summary>
    /// Сума коштів, прийнятих за відпущене пальне (15.2 цифри)-->
    /// </summary>
    [XmlElement("REALIZCOST", Form = XmlSchemaForm.Unqualified)]
    public decimal IssuedCost { get; set; }

    /// <summary>
    /// Обсяг залишку пального у мілілітрах (15.2 цифри).
    /// </summary>
    [XmlElement("REMAINS", Form = XmlSchemaForm.Unqualified)]
    public decimal Remains { get; set; }

    /// <summary>
    /// Суми отриманих коштів по формам оплати.
    /// </summary>
    [XmlArray("PAYFORMS", Form = XmlSchemaForm.Unqualified)]
    [XmlArrayItem("ROW", Form = XmlSchemaForm.Unqualified)]
    public Collection<ZReportFuelPaymentForm>? PaymentForms { get; set; }

    [Range(typeof(int), "1", "999999")]
    [Required]
    [XmlAttribute("ROWNUM")]
    public int RowNumber { get; set; }
}