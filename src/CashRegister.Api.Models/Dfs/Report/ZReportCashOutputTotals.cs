using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CashRegister.Api.Models.Dfs.Report;

/// <summary>
/// Підсумки видачі готівки.
/// </summary>
[GeneratedCode("XmlSchemaClassGenerator", "2.0.711.0")]
[Serializable]
[XmlType("ZCash", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class ZReportCashOutputTotals
{
    /// <summary>
    /// Загальна сума (15.2 цифри).
    /// </summary>
    [RegularExpression("\\-{0,1}[0-9]+\\.[0-9]{2}")]
    [Required]
    [XmlElement("SUM", Form = XmlSchemaForm.Unqualified)]
    public decimal Sum { get; set; }

    /// <summary>
    /// Сума комісії (15.2 цифри).
    /// </summary>
    [RegularExpression("\\-{0,1}[0-9]+\\.[0-9]{2}")]
    [XmlElement("COMMISSION", Form = XmlSchemaForm.Unqualified)]
    public decimal Commission { get; set; }

    /// <summary>
    /// Кількість чеків (числовий).
    /// </summary>
    [Required]
    [XmlElement("ORDERSCNT", Form = XmlSchemaForm.Unqualified)]
    public uint OrdersCount { get; set; }
}