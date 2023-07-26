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
[XmlType("CTotal", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class CheckTotal
{
    /// <summary>
    /// Загальна сума (15.2 цифри) (наприклад, 1000.00).
    /// </summary>
    [RegularExpression("\\-{0,1}[0-9]+\\.[0-9]{2}")]
    [XmlElement("SUM", Form = XmlSchemaForm.Unqualified)]
    public decimal Sum { get; set; }

    /// <summary>
    /// Загальна сума коштів, виданих клієнту ломбарда (15.2 цифри) (наприклад, 1000.00).
    /// </summary>
    [RegularExpression("\\-{0,1}[0-9]+\\.[0-9]{2}")]
    [XmlElement("PWNSUMISSUED", Form = XmlSchemaForm.Unqualified)]
    public decimal PawnShopIssuedSum { get; set; }

    /// <summary>
    /// Загальна сума коштів, одержаних від клієнта ломбарда (15.2 цифри) (наприклад, 1000.00).
    /// </summary>
    [RegularExpression("\\-{0,1}[0-9]+\\.[0-9]{2}")]
    [XmlElement("PWNSUMRECEIVED", Form = XmlSchemaForm.Unqualified)]
    public decimal PawnShopReceivedSum { get; set; }

    /// <summary>
    /// Заокруглення (15.2 цифри) (наприклад, 0.71).
    /// </summary>
    [RegularExpression("\\-{0,1}[0-9]+\\.[0-9]{2}")]
    [XmlElement("RNDSUM", Form = XmlSchemaForm.Unqualified)]
    public decimal RoundingSum { get; set; }

    /// <summary>
    /// Загальна сума без заокруглення (15.2 цифри) (наприклад, 1000.71).
    /// </summary>
    [RegularExpression("\\-{0,1}[0-9]+\\.[0-9]{2}")]
    [XmlElement("NORNDSUM", Form = XmlSchemaForm.Unqualified)]
    public decimal NoRoundingSum { get; set; }

    /// <summary>
    /// Сума чеку без урахування податків/зборів (15.2 цифри).
    /// </summary>
    [RegularExpression("\\-{0,1}[0-9]+\\.[0-9]{2}")]
    [XmlElement("NOTAXSUM", Form = XmlSchemaForm.Unqualified)]
    public decimal NoTaxSum { get; set; }

    /// <summary>
    /// Сума комісії (15.2 цифри).
    /// </summary>
    [RegularExpression("\\-{0,1}[0-9]+\\.[0-9]{2}")]
    [XmlElement("COMMISSION", Form = XmlSchemaForm.Unqualified)]
    public decimal Commission { get; set; }

    /// <summary>
    /// Тип застосування знижки/націнки (числовий):
    /// 0–Попередній продаж, 1–Проміжний підсумок, 2–Спеціальна.
    /// </summary>
    [XmlElement("USAGETYPE", Form = XmlSchemaForm.Unqualified)]
    public string? UsageType { get; set; }

    /// <summary>
    /// Cума на яку нараховується знижка/націнка (15.2 цифри).
    /// </summary>
    [RegularExpression("\\-{0,1}[0-9]+\\.[0-9]{2}")]
    [XmlElement("SUBCHECK", Form = XmlSchemaForm.Unqualified)]
    public decimal SubCheck { get; set; }

    /// <summary>
    /// Тип знижки/націнки (числовий):
    /// 0–Сумова, 1–Відсоткова.
    /// </summary>
    [XmlElement("DISCOUNTTYPE", Form = XmlSchemaForm.Unqualified)]
    public EDiscountType DiscountType { get; set; }

    /// <summary>
    /// Відсоток знижки/націнки, для відсоткових знижок/націнок (не зазначається при фіксованій сумі знижки/націнки) (15.2 цифри).
    /// </summary>
    [RegularExpression("\\-{0,1}[0-9]+\\.[0-9]{2}")]
    [XmlElement("DISCOUNTPERCENT", Form = XmlSchemaForm.Unqualified)]
    public decimal DiscountPercent { get; set; }

    /// <summary>
    /// Загальна сума знижки/націнки (15.2 цифри).
    /// </summary>
    [RegularExpression("\\-{0,1}[0-9]+\\.[0-9]{2}")]
    [XmlElement("DISCOUNTSUM", Form = XmlSchemaForm.Unqualified)]
    public decimal DiscountSum { get; set; }

    public void WriteXml(XmlTextWriter xmlTextWriter)
    {
        xmlTextWriter.WriteStartElement("CHECKTOTAL");
        xmlTextWriter.WriteElementD2("SUM", Sum);
        xmlTextWriter.WriteElementD2("DISCOUNTSUM", DiscountSum);
        xmlTextWriter.WriteEndElement();
    }
}