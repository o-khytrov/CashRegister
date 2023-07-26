using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CashRegister.Api.Models.Dfs.Types;

/// <summary>
///     <para>
///         Загальний тип для визначення формату ІНДИВІДУАЛЬНИЙ ПОДАТКОВИЙ НОМЕР з можливістю внесення
///         0 (нуля) в колонці
///     </para>
/// </summary>
[Description("Загальний тип для визначення формату ІНДИВІДУАЛЬНИЙ ПОДАТКОВИЙ НОМЕР з можливістю" +
             " внесення 0 (нуля) в колонці")]
[GeneratedCode("XmlSchemaClassGenerator", "2.0.711.0")]
[Serializable]
[XmlType("HIPNColumn0", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class HIPNColumn0
{
    /// <summary>
    ///     <para xml:lang="en">Gets or sets the text value.</para>
    ///     <para xml:lang="en">Pattern: (0)|([0-9]{6,12})|([АБВГДЕЄЖЗИІКЛМНОПРСТУФХЦЧШЩЮЯ]{2}[0-9]{6}).</para>
    /// </summary>
    [RegularExpression("(0)|([0-9]{6,12})|([АБВГДЕЄЖЗИІКЛМНОПРСТУФХЦЧШЩЮЯ]{2}[0-9]{6})")]
    [XmlText]
    public string Value { get; set; }
}