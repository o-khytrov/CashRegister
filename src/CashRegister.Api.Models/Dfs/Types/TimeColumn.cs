using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CashRegister.Api.Models.Dfs.Types;

/// <summary>
///     <para>
///         Загальний тип для визначення формату ЧАС в колонці, що мають вигляд (ГГХХСС
///         (HHMMSS))
///     </para>
/// </summary>
[Description("Загальний тип для визначення формату ЧАС в колонці, що мають вигляд (ГГХХСС (HHMM" +
             "SS))")]
[GeneratedCode("XmlSchemaClassGenerator", "2.0.711.0")]
[Serializable]
[XmlType("TimeColumn", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class TimeColumn
{
    /// <summary>
    ///     <para xml:lang="en">Gets or sets the text value.</para>
    ///     <para xml:lang="en">Minimum length: 6.</para>
    ///     <para xml:lang="en">Maximum length: 6.</para>
    ///     <para xml:lang="en">Pattern: (([0-1][0-9])|(2[0-3]))[0-5][0-9][0-5][0-9].</para>
    /// </summary>
    [MinLength(6)]
    [MaxLength(6)]
    [RegularExpression("(([0-1][0-9])|(2[0-3]))[0-5][0-9][0-5][0-9]")]
    [XmlText]
    public string Value { get; set; }
}