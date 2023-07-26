using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using CashRegister.Api.Models.Dfs.Enums;
using CashRegister.Api.Models.Dfs.Extensions;

namespace CashRegister.Api.Models.Dfs.Check;

[GeneratedCode("XmlSchemaClassGenerator", "2.0.711.0")]
[Serializable]
[XmlType("TROWSPAY", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class CheckPaymentRow
{
    /// <summary>
    /// Код форми оплати (числовий):
    /// 0–Готівка, 1–Банківська картка, 2-Попередня оплата, 3-Кредит.
    /// </summary>
    [Required]
    [XmlElement("PAYFORMCD", Form = XmlSchemaForm.Unqualified)]
    public EPaymentForm PaymentFormCode { get; set; }

    /// <summary>
    /// Найменування форми оплати (128 символів).
    /// </summary>
    [Required]
    [XmlElement("PAYFORMNM", Form = XmlSchemaForm.Unqualified)]
    public string? PaymentFormName { get; set; }

    /// <summary>
    /// Сума оплати (15.2 цифри).
    /// </summary>
    [XmlElement("SUM", Form = XmlSchemaForm.Unqualified)]
    public decimal Sum { get; set; }

    /// <summary>
    /// Сума внесених коштів (15.2 цифри).
    /// </summary>
    [XmlElement("PROVIDED", Form = XmlSchemaForm.Unqualified)]
    public decimal Provided { get; set; }

    /// <summary>
    /// Решта (не зазначається, якщо решта відсутня) (15.2 цифри)
    /// </summary>
    [XmlElement("REMAINS", Form = XmlSchemaForm.Unqualified)]
    public decimal Remains { get; set; }

    /// <summary>
    /// Платіжні системи
    /// </summary>
    [XmlArray("PAYSYS", Form = XmlSchemaForm.Unqualified)]
    [XmlArrayItem("ROW", Form = XmlSchemaForm.Unqualified)]
    public List<PaymentSystemDetails>? PaymentSystemDetails { get; set; }

    [Range(typeof(int), "1", "999999")]
    [Required]
    [XmlAttribute("ROWNUM")]
    public int RowNumber { get; set; }

    public void WriteXml(XmlTextWriter wr)
    {
        wr.WriteStartElement("ROW");
        wr.WriteAttributeString("ROWNUM", RowNumber.ToString());
        wr.WriteElement("PAYFORMCD", (int) PaymentFormCode);
        wr.WriteElementNn("PAYFORMNM", PaymentFormName);
        wr.WriteElementD2NN("SUM", Sum);
        wr.WriteElementD2NN("PROVIDED", Provided);
        wr.WriteElementD2NN("REMAINS", Remains);
        wr.WriteEndElement();
    }
}