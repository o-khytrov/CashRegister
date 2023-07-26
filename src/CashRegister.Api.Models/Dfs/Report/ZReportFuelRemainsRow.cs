using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CashRegister.Api.Models.Dfs.Report;

/// <summary>
/// Залишки пального в розхідних резервуарах.
/// </summary>
[GeneratedCode("XmlSchemaClassGenerator", "2.0.711.0")]
[Serializable]
[XmlType("TROWSFUELREMAINS", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class ZReportFuelRemainsRow
{
    /// <summary>
    /// Найменування товару (пального) (текст).
    /// </summary>
    [Required]
    [XmlElement("NAME", Form = XmlSchemaForm.Unqualified)]
    public string? Name { get; set; }

    /// <summary>
    /// Номер розхідного резервуару (64 символи).
    /// </summary>
    [Required]
    [XmlElement("TANKNUM", Form = XmlSchemaForm.Unqualified)]
    public string? TankNumber { get; set; }

    /// <summary>
    /// Номер паливно-роздавальної колонки (64 символи).
    /// </summary>
    [XmlElement("COLUMNNUM", Form = XmlSchemaForm.Unqualified)]
    public string? ColumnNumber { get; set; }

    /// <summary>
    /// Номер крану паливно-роздавальної колонки (64 символи).
    /// </summary>
    [XmlElement("FAUCETNUM", Form = XmlSchemaForm.Unqualified)]
    public string? FaucetNumber { get; set; }

    /// <summary>
    /// Обсяг залишку пального у мілілітрах (15.2 цифри).
    /// </summary>
    [Required]
    [XmlElement("REMAINS", Form = XmlSchemaForm.Unqualified)]
    public decimal Remains { get; set; }

    [Range(typeof(int), "1", "999999")]
    [Required]
    [XmlAttribute("ROWNUM")]
    public int RowNumber { get; set; }
}