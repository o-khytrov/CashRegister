using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CashRegister.Api.Models.Dfs.Types;

[GeneratedCode("XmlSchemaClassGenerator", "2.0.711.0")]
[Serializable]
[XmlType("Str64Column", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class Str64Column
{
    /// <summary>
    ///     <para xml:lang="en">Gets or sets the text value.</para>
    ///     <para xml:lang="en">Maximum length: 64.</para>
    /// </summary>
    [MaxLength(64)]
    [XmlText]
    public string Value { get; set; }
}