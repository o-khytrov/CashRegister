using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CashRegister.Api.Models.Dfs.Report;

/// <summary>
/// Підсумки операцій для АЗС.
/// </summary>
[GeneratedCode("XmlSchemaClassGenerator", "2.0.711.0")]
[Serializable]
[XmlType("ZFuel", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class ZReportFuelTotals
{
    /// <summary>
    /// Підсумки по видам пального.
    /// </summary>
    [Required]
    [XmlArray("DETAILS", Form = XmlSchemaForm.Unqualified)]
    [XmlArrayItem("ROW", Form = XmlSchemaForm.Unqualified)]
    public Collection<ZReportFuelDetailsRow>? FuelDetails { get; set; }

    /// <summary>
    /// Залишки пального в розхідних резервуарах.
    /// </summary>
    [XmlArray("REMAINS", Form = XmlSchemaForm.Unqualified)]
    [XmlArrayItem("ROW", Form = XmlSchemaForm.Unqualified)]
    public Collection<ZReportFuelRemainsRow>? FuelRemains { get; set; }
}