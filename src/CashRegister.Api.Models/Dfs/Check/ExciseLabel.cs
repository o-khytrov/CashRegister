using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;
using CashRegister.Api.Models.Dfs.Types;

namespace CashRegister.Api.Models.Dfs.Check;

[GeneratedCode("XmlSchemaClassGenerator", "2.0.711.0")]
[Serializable]
[XmlType("TROWSEXCISELABEL", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class ExciseLabel
{
    /// <summary>
    /// Серія та номер марки акцизного податку.
    /// </summary>
    [Required]
    [XmlElement("EXCISELABEL", Form = XmlSchemaForm.Unqualified)]
    public Str64Column? ExciseLabelNumber { get; set; }

    /// <summary>
    ///     <para xml:lang="en">Minimum inclusive value: 1.</para>
    ///     <para xml:lang="en">Maximum inclusive value: 999999.</para>
    /// </summary>
    [Range(typeof(int), "1", "999999")]
    [Required]
    [XmlAttribute("ROWNUM")]
    public int RowNumber { get; set; }
}