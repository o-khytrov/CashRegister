using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CashRegister.Api.Models.Dfs.Types;

[GeneratedCode("XmlSchemaClassGenerator", "2.0.711.0")]
[Serializable]
[XmlType("Decimal8Column_R", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class Decimal8Column_R
{
    /// <summary>
    ///     <para xml:lang="en">Gets or sets the text value.</para>
    ///     <para xml:lang="en">Pattern: \-{0,1}[0-9]+(\.[0-9]{1,8}){0,1}.</para>
    /// </summary>
    [RegularExpression("\\-{0,1}[0-9]+(\\.[0-9]{1,8}){0,1}")]
    [XmlText]
    public decimal Value { get; set; }
}