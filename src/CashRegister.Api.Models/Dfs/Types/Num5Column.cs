using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CashRegister.Api.Models.Dfs.Types;

[GeneratedCode("XmlSchemaClassGenerator", "2.0.711.0")]
[Serializable]
[XmlType("Num5Column", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class Num5Column
{
    /// <summary>
    ///     <para xml:lang="en">Gets or sets the text value.</para>
    ///     <para xml:lang="en">Minimum inclusive value: 1.</para>
    ///     <para xml:lang="en">Maximum inclusive value: 99999.</para>
    /// </summary>
    [Range(typeof(decimal), "1", "99999")]
    [XmlText]
    public uint Value { get; set; }
}