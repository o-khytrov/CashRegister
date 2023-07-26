using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using CashRegister.Api.Models.Dfs.Extensions;

namespace CashRegister.Api.Models.Dfs.Report;

[GeneratedCode("XmlSchemaClassGenerator", "2.0.711.0")]
[Serializable]
[XmlType("ZHead", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class ZReportHeader
{
    /// <summary>
    /// Унікальний ідентифікатор документа (GUID).
    /// </summary>
    [Required]
    [XmlElement("UID", Form = XmlSchemaForm.Unqualified)]
    public Guid Uid { get; set; }

    /// <summary>
    /// ЄДРПОУ/ДРФО/№ паспорта продавця (10 символів).
    /// </summary>
    [MaxLength(10)]
    [RegularExpression("([0-9]{5,10}|[АБВГДЕЄЖЗИІКЛМНОПРСТУФХЦЧШЩЮЯ]{2}[0-9]{6})")]
    [Required]
    [XmlElement("TIN", Form = XmlSchemaForm.Unqualified)]
    public string? Tin { get; set; }

    /// <summary>
    /// Податковий номер або Індивідуальний номер платника ПДВ (12 символів).
    /// </summary>
    [RegularExpression("(0)|([0-9]{6,12})|([АБВГДЕЄЖЗИІКЛМНОПРСТУФХЦЧШЩЮЯ]{2}[0-9]{6})")]
    [XmlElement("IPN", Form = XmlSchemaForm.Unqualified)]
    public string? Ipn { get; set; }

    /// <summary>
    /// Найменування продавця (256 символів).
    /// </summary>
    [MaxLength(256)]
    [Required]
    [XmlElement("ORGNM", Form = XmlSchemaForm.Unqualified)]
    public string? OrganizationName { get; set; }

    /// <summary>
    /// Найменування точки продажу (256 символів).
    /// </summary>
    [MaxLength(256)]
    [Required]
    [XmlElement("POINTNM", Form = XmlSchemaForm.Unqualified)]
    public string? PointName { get; set; }

    /// <summary>
    /// Адреса точки продажу(256 символів).
    /// </summary>
    [MaxLength(256)]
    [XmlElement("POINTADDR", Form = XmlSchemaForm.Unqualified)]
    public string? PointAddress { get; set; }

    /// <summary>
    /// Дата операції (ддммрррр).
    /// </summary>
    [MinLength(8)]
    [MaxLength(8)]
    [RegularExpression(
        @"((((0[1-9]|[1-2][0-9])(0(1|[3-9])|1[0-2]))|(30(0(1|[3-9])|1[0-2]))|(31(01|03|05|07|08|10|12)))(19|20)\d{2})|((0[1-9]|[1-2][0-9])02(19|20)(([0|2|4|6|8][0|4|8])|([1|3|5|7|9][2|6]))|(0[1-9]|[1-2][0-8]|19)02(19|20)(([0|2|4|6|8][1-3|5-7|9])|([1|3|5|7|9][0-1|3-5|7-9])))")]
    [Required]
    [XmlElement("ORDERDATE", Form = XmlSchemaForm.Unqualified)]
    public string? OrderDate => DateTime.ToString("ddMMyyyy");

    /// <summary>
    /// Час операції (ггххсс).
    /// </summary>
    [MinLength(6)]
    [MaxLength(6)]
    [RegularExpression("(([0-1][0-9])|(2[0-3]))[0-5][0-9][0-5][0-9]")]
    [Required]
    [XmlElement("ORDERTIME", Form = XmlSchemaForm.Unqualified)]
    public string? OrderTime => DateTime.ToString("HHmmss");

    /// <summary>
    /// Локальний номер документа (числовий).
    /// </summary>
    [Required]
    [XmlElement("ORDERNUM", Form = XmlSchemaForm.Unqualified)]
    public ulong OrderNumber { get; set; }

    /// <summary>
    /// Локальний номер програмного реєстратора розрахункових операцій (числовий).
    /// </summary>
    [Required]
    [XmlElement("CASHDESKNUM", Form = XmlSchemaForm.Unqualified)]
    public ulong CashRegisterLocalNumber { get; set; }

    /// <summary>
    /// Фіскальний номер програмного реєстратора розрахункових операцій (числовий).
    /// </summary>
    [Required]
    [XmlElement("CASHREGISTERNUM", Form = XmlSchemaForm.Unqualified)]
    public ulong CashRegisterFiscalNumber { get; set; }

    /// <summary>
    /// ПІБ касира (128 символів).
    /// </summary>
    [MaxLength(128)]
    [XmlElement("CASHIER", Form = XmlSchemaForm.Unqualified)]
    public string? Cashier { get; set; }

    /// <summary>
    /// Версія формату документа (числовий).
    /// </summary>
    [Required]
    [XmlElement("VER", Form = XmlSchemaForm.Unqualified)]
    public int Ver { get; set; }

    /// <summary>
    /// Фіскальний номер документа (128 символів).
    /// </summary>
    [MaxLength(128)]
    [XmlElement("ORDERTAXNUM", Form = XmlSchemaForm.Unqualified)]
    public string? OrderTaxNumber { get; set; }

    /// <summary>
    /// Ознака офлайн документа.
    /// </summary>
    [XmlElement("OFFLINE", Form = XmlSchemaForm.Unqualified)]
    public bool Offline { get; set; }

    /// <summary>
    /// Геш попереднього документа в режимі офлайн (64 символи).
    /// </summary>
    [MaxLength(64)]
    [XmlElement("PREVDOCHASH", Form = XmlSchemaForm.Unqualified)]
    public string? PrevDocumentHash { get; set; }

    /// <summary>
    /// Документ відкликано.
    /// </summary>
    [XmlElement("REVOKED", Form = XmlSchemaForm.Unqualified)]
    public bool Revoked { get; set; }

    /// <summary>
    /// Ознака тестового нефіскального документа.
    /// </summary>
    [XmlElement("TESTING", Form = XmlSchemaForm.Unqualified)]
    public bool Testing { get; set; } 

    [XmlIgnore]
    public DateTime DateTime { get; set; }

    public void WriteXml(XmlTextWriter writer)
    {
        writer.WriteStartElement("ZREPHEAD");
        writer.WriteElement("UID", Uid);
        writer.WriteElement("TIN", Tin);
        writer.WriteElement("IPN", Ipn);
        writer.WriteElement("ORGNM", OrganizationName);
        writer.WriteElement("POINTNM", PointName);
        writer.WriteElement("POINTADDR", PointAddress);
        writer.WriteElement("ORDERDATE", OrderDate);
        writer.WriteElement("ORDERTIME", OrderTime);
        writer.WriteElement("ORDERNUM", OrderNumber);
        writer.WriteElement("CASHDESKNUM", CashRegisterLocalNumber);
        writer.WriteElement("CASHREGISTERNUM", CashRegisterFiscalNumber);
        writer.WriteElement("CASHIER", Cashier);
        writer.WriteElement("VER", Ver);
        if (!string.IsNullOrWhiteSpace(OrderTaxNumber))
            writer.WriteElement("ORDERTAXNUM", OrderTaxNumber);
        if (Offline)
        {
            writer.WriteElement("OFFLINE", "true");
            writer.WriteElement("PREVDOCHASH", PrevDocumentHash);
        }

        writer.WriteElement("TESTING", Testing.ToString().ToLower());

        writer.WriteEndElement();
    }
}