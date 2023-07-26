using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;
using CashRegister.Api.Models.Dfs.Types;

namespace CashRegister.Api.Models.Dfs.Report;

[GeneratedCode("XmlSchemaClassGenerator", "2.0.711.0")]
[Serializable]
[XmlType("TROWSFUELPAYFORMS", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class ZReportFuelPaymentForm
{
    [Required]
    [XmlElement("PAYFORMCD", Form = XmlSchemaForm.Unqualified)]
    public Decimal0Column PAYFORMCD { get; set; }

    [Required]
    [XmlElement("PAYFORMNM", Form = XmlSchemaForm.Unqualified)]
    public string PAYFORMNM { get; set; }

    [Required]
    [XmlElement("SUM", Form = XmlSchemaForm.Unqualified)]
    public Decimal2Column SUM { get; set; }

    [Required]
    [XmlElement("AMOUNT", Form = XmlSchemaForm.Unqualified)]
    public Decimal2Column AMOUNT { get; set; }

    /// <summary>
    ///     <para xml:lang="en">Minimum inclusive value: 1.</para>
    ///     <para xml:lang="en">Maximum inclusive value: 999999.</para>
    /// </summary>
    [Range(typeof(int), "1", "999999")]
    [Required]
    [XmlAttribute("ROWNUM")]
    public int ROWNUM { get; set; }
}