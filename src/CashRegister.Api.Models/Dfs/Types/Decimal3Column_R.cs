using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CashRegister.Api.Models.Dfs.Types;

[Serializable]
[XmlType("Decimal3Column_R", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class Decimal3Column_R
{
    /// <summary>
    ///     <para xml:lang="en">Gets or sets the text value.</para>
    ///     <para xml:lang="en">Pattern: \-{0,1}[0-9]+(\.[0-9]{1,3}){0,1}.</para>
    /// </summary>
    [RegularExpression("\\-{0,1}[0-9]+(\\.[0-9]{1,3}){0,1}")]
    [XmlText]
    public decimal Value { get; set; }
}