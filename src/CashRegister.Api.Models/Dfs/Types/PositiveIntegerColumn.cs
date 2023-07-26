using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CashRegister.Api.Models.Dfs.Types;

[GeneratedCode("XmlSchemaClassGenerator", "2.0.711.0")]
[Serializable]
[XmlType("PositiveIntegerColumn", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class PositiveIntegerColumn
{
    /// <summary>
    ///     <para xml:lang="en">Gets or sets the text value.</para>
    /// </summary>
    [XmlText]
    public string Value { get; set; }
}