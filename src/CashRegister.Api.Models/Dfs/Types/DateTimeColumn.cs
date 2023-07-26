using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CashRegister.Api.Models.Dfs.Types;

/// <summary>
///     <para>
///         Загальний тип для визначення формату ДАТА І ЧАС в колонці, що мають вигляд (ДДММРРРРГГХХСС
///         (DDMMYYYYHHMMSS))
///     </para>
/// </summary>
[Description("Загальний тип для визначення формату ДАТА І ЧАС в колонці, що мають вигляд (ДДММР" +
             "РРРГГХХСС (DDMMYYYYHHMMSS))")]
[GeneratedCode("XmlSchemaClassGenerator", "2.0.711.0")]
[Serializable]
[XmlType("DateTimeColumn", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class DateTimeColumn
{
    /// <summary>
    ///     <para xml:lang="en">Gets or sets the text value.</para>
    ///     <para xml:lang="en">Minimum length: 14.</para>
    ///     <para xml:lang="en">Maximum length: 14.</para>
    ///     <para xml:lang="en">
    ///         Pattern:
    ///         (((((0[1-9]|[1-2][0-9])(0(1|[3-9])|1[0-2]))|(30(0(1|[3-9])|1[0-2]))|(31(01|03|05|07|08|10|12)))(19|20)\d{2})|((0[1-9]|[1-2][0-9])02(19|20)(([0|2|4|6|8][0|4|8])|([1|3|5|7|9][2|6]))|(0[1-9]|[1-2][0-8]|19)02(19|20)(([0|2|4|6|8][1-3|5-7|9])|([1|3|5|7|9][0-1|3-5|7-9]))))((([0-1][0-9])|(2[0-3]))[0-5][0-9][0-5][0-9]).
    ///     </para>
    /// </summary>
    [MinLength(14)]
    [MaxLength(14)]
    [RegularExpression(
        @"(((((0[1-9]|[1-2][0-9])(0(1|[3-9])|1[0-2]))|(30(0(1|[3-9])|1[0-2]))|(31(01|03|05|07|08|10|12)))(19|20)\d{2})|((0[1-9]|[1-2][0-9])02(19|20)(([0|2|4|6|8][0|4|8])|([1|3|5|7|9][2|6]))|(0[1-9]|[1-2][0-8]|19)02(19|20)(([0|2|4|6|8][1-3|5-7|9])|([1|3|5|7|9][0-1|3-5|7-9]))))((([0-1][0-9])|(2[0-3]))[0-5][0-9][0-5][0-9])")]
    [XmlText]
    public string Value { get; set; }
}