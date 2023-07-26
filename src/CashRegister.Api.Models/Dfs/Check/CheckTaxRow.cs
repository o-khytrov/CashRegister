using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;
using CashRegister.Api.Models.Dfs.Types;

namespace CashRegister.Api.Models.Dfs.Check;

[GeneratedCode("XmlSchemaClassGenerator", "2.0.711.0")]
[Serializable]
[XmlType("TROWSTAX", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class CheckTaxRow
{
    /// <summary>
    /// Код виду податку/збору (числовий):
    /// 0-ПДВ,1-Акциз,2-ПФ.
    /// </summary>
    [Required]
    [XmlElement("TYPE", Form = XmlSchemaForm.Unqualified)]
    public string? TaxType { get; set; }

    /// <summary>
    /// Найменування виду податку/збору (64 символи).
    /// </summary>
    [Required]
    [XmlElement("NAME", Form = XmlSchemaForm.Unqualified)]
    public Str64Column? TaxName { get; set; }

    /// <summary>
    /// Літерне позначення виду і ставки податку/збору (А,Б,В,Г,...) (1 символ).
    /// </summary>
    [XmlElement("LETTER", Form = XmlSchemaForm.Unqualified)]
    public TaxColumn? Letter { get; set; }

    /// <summary>
    /// Відсоток податку/збору (15.2 цифри).
    /// </summary>
    [Required]
    [XmlElement("PRC", Form = XmlSchemaForm.Unqualified)]
    public Decimal2Column? Percent { get; set; }

    /// <summary>
    /// Ознака податку/збору, не включеного у вартість.
    /// </summary>
    [XmlElement("SIGN", Form = XmlSchemaForm.Unqualified)]
    public bool Sign { get; set; }

    /// <summary>
    /// Сума обсягів для розрахування податку/збору (15.2 цифри).
    /// </summary>
    [Required]
    [XmlElement("TURNOVER", Form = XmlSchemaForm.Unqualified)]
    public Decimal2Column? Turnover { get; set; }

    /// <summary>
    /// Сума обсягів для розрахування податку/збору з урахуванням знижки (15.2 цифри).
    /// </summary>
    [XmlElement("TURNOVERDISCOUNT", Form = XmlSchemaForm.Unqualified)]
    public Decimal2Column? TurnoverDiscount { get; set; }

    /// <summary>
    /// Вихідна сума для розрахування податку/збору (15.2 цифри).
    /// </summary>
    [XmlElement("SOURCESUM", Form = XmlSchemaForm.Unqualified)]
    public Decimal2Column? SourceSum { get; set; }

    /// <summary>
    /// Сума податку/збору (15.2 цифри).
    /// </summary>
    [Required]
    [XmlElement("SUM", Form = XmlSchemaForm.Unqualified)]
    public Decimal2Column? Sum { get; set; }

    /// <summary>
    ///     <para xml:lang="en">Minimum inclusive value: 1.</para>
    ///     <para xml:lang="en">Maximum inclusive value: 999999.</para>
    /// </summary>
    [Range(typeof(int), "1", "999999")]
    [Required]
    [XmlAttribute("ROWNUM")]
    public int RowNumber { get; set; }
}