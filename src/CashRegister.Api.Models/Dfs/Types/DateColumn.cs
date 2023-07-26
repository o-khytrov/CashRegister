using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CashRegister.Api.Models.Dfs.Types;

/// <summary>
///     <para>
///         Загальний тип для визначення формату ДАТА в колонці, що мають вигляд (ДДММРРРР
///         (DDMMYYYY))
///     </para>
/// </summary>
[Description("Загальний тип для визначення формату ДАТА в колонці, що мають вигляд (ДДММРРРР (D" +
             "DMMYYYY))")]
[GeneratedCode("XmlSchemaClassGenerator", "2.0.711.0")]
[Serializable]
[XmlType("DateColumn", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class DateColumn
{
    /// <summary>
    ///     <para xml:lang="en">Gets or sets the text value.</para>
    ///     <para xml:lang="en">Minimum length: 8.</para>
    ///     <para xml:lang="en">Maximum length: 8.</para>
    ///     <para xml:lang="en">
    ///         Pattern:
    ///         ((((0[1-9]|[1-2][0-9])(0(1|[3-9])|1[0-2]))|(30(0(1|[3-9])|1[0-2]))|(31(01|03|05|07|08|10|12)))(19|20)\d{2})|((0[1-9]|[1-2][0-9])02(19|20)(([0|2|4|6|8][0|4|8])|([1|3|5|7|9][2|6]))|(0[1-9]|[1-2][0-8]|19)02(19|20)(([0|2|4|6|8][1-3|5-7|9])|([1|3|5|7|9][0-1|3-5|7-9]))).
    ///     </para>
    /// </summary>
    [MinLength(8)]
    [MaxLength(8)]
    [RegularExpression(
        @"((((0[1-9]|[1-2][0-9])(0(1|[3-9])|1[0-2]))|(30(0(1|[3-9])|1[0-2]))|(31(01|03|05|07|08|10|12)))(19|20)\d{2})|((0[1-9]|[1-2][0-9])02(19|20)(([0|2|4|6|8][0|4|8])|([1|3|5|7|9][2|6]))|(0[1-9]|[1-2][0-8]|19)02(19|20)(([0|2|4|6|8][1-3|5-7|9])|([1|3|5|7|9][0-1|3-5|7-9])))")]
    [XmlText]
    public string Value { get; set; }
}