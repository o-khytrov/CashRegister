using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CashRegister.Api.Models.Dfs.Types;

[GeneratedCode("XmlSchemaClassGenerator", "2.0.711.0")]
[Serializable]
[XmlType("Decimal0Column", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class Decimal0Column
{
    /// <summary>
    ///     <para xml:lang="en">Gets or sets the text value.</para>
    ///     <para xml:lang="en">Pattern: \-{0,1}[0-9]+(\.0{1,2}){0,1}.</para>
    /// </summary>
    [RegularExpression("\\-{0,1}[0-9]+(\\.0{1,2}){0,1}")]
    [XmlText]
    public decimal Value { get; set; }
}