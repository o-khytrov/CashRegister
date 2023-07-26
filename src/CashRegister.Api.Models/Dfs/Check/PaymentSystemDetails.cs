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
[XmlType("TROWSPAYSYS", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class PaymentSystemDetails
{
    /// <summary>
    /// Податковий номер платіжної системи (64 символи).
    /// </summary>
    [XmlElement("TAXNUM", Form = XmlSchemaForm.Unqualified)]
    public Str64Column? PaymentSystemTaxNumber { get; set; }

    /// <summary>
    /// Найменування платіжної системи (текст).
    /// </summary>
    [XmlElement("NAME", Form = XmlSchemaForm.Unqualified)]
    public string? PaymentSystemName { get; set; }

    /// <summary>
    /// Податковий номер еквайра торговця (64 символи).
    /// </summary>
    [XmlElement("ACQUIREPN", Form = XmlSchemaForm.Unqualified)]
    public Str64Column? AcquireTaxNumber { get; set; }

    /// <summary>
    /// Найменування еквайра торговця (текст).
    /// </summary>
    [XmlElement("ACQUIRENM", Form = XmlSchemaForm.Unqualified)]
    public string? AcquireName { get; set; }

    /// <summary>
    /// Ідентифікатор транзакції, що надається еквайром та ідентифікує операцію в платіжній системі (128 символів).
    /// </summary>
    [XmlElement("ACQUIRETRANSID", Form = XmlSchemaForm.Unqualified)]
    public Str128Column? AcquireTransactionId { get; set; }

    /// <summary>
    /// POS-термінал. Дата та час транзакції (ддммррррггххсс).
    /// </summary>
    [XmlElement("POSTRANSDATE", Form = XmlSchemaForm.Unqualified)]
    public DateTimeColumn? PosTransactionDateTime { get; set; }

    /// <summary>
    /// POS-термінал. Номер чека транзакції (128 символів).
    /// </summary>
    [XmlElement("POSTRANSNUM", Form = XmlSchemaForm.Unqualified)]
    public Str128Column? PosTransactionNumber { get; set; }

    /// <summary>
    /// Ідентифікатор платіжного пристрою (128 символів).
    /// </summary>
    [XmlElement("DEVICEID", Form = XmlSchemaForm.Unqualified)]
    public Str128Column? DeviceId { get; set; }

    /// <summary>
    /// Реквізити електронного платіжного засобу (128 символів).
    /// </summary>
    [XmlElement("EPZDETAILS", Form = XmlSchemaForm.Unqualified)]
    public Str128Column? ElectronicPaymentDeviceDetails { get; set; }

    /// <summary>
    /// Код авторизації (64 символи).
    /// </summary>
    [XmlElement("AUTHCD", Form = XmlSchemaForm.Unqualified)]
    public Str64Column? AuthCode { get; set; }

    /// <summary>
    /// Сума оплати (15.2 цифри).
    /// </summary>
    [XmlElement("SUM", Form = XmlSchemaForm.Unqualified)]
    public Decimal2Column? Sum { get; set; }

    /// <summary>
    /// Сума комісії (15.2 цифри).
    /// </summary>
    [XmlElement("COMMISSION", Form = XmlSchemaForm.Unqualified)]
    public Decimal2Column? Commission { get; set; }

    [Range(typeof(int), "1", "999999")]
    [Required]
    [XmlAttribute("ROWNUM")]
    public int RowNumber { get; set; }
}