using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;
using CashRegister.Api.Models.Dfs.Enums;

namespace CashRegister.Api.Models.Dfs.Report;

/// <summary>
/// Підсумки по формам оплати.
/// </summary>
[GeneratedCode("XmlSchemaClassGenerator", "2.0.711.0")]
[Serializable]
[XmlType("TROWSPAYFORMS", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class PaymentFormsTotals
{
    /// <summary>
    /// Код форми оплати (числовий)
    /// :0–Готівка, 1–Банківська картка, 2-Попередня оплата, 3-Кредит.
    /// </summary>
    [Required]
    [XmlElement("PAYFORMCD", Form = XmlSchemaForm.Unqualified)]
    public EPaymentForm PaymentFormCode { get; set; }

    /// <summary>
    ///  Найменування форми оплати (128 символів).
    /// </summary>
    [Required]
    [XmlElement("PAYFORMNM", Form = XmlSchemaForm.Unqualified)]
    public string? PaymentFormName { get; set; }

    /// <summary>
    /// Сума оплати (15.2 цифри).
    /// </summary>
    [Required]
    [XmlElement("SUM", Form = XmlSchemaForm.Unqualified)]
    public decimal Sum { get; set; }

    [Range(typeof(int), "1", "999999")]
    [Required]
    [XmlAttribute("ROWNUM")]
    public int RowNumber { get; set; }
}