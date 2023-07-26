using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;
using CashRegister.Api.Models.Dfs.Types;

namespace CashRegister.Api.Models.Dfs.Check;

/// <summary>
/// Реквізити програмно-технічного комплексу самообслуговування (ПТКС).
/// </summary>
[GeneratedCode("XmlSchemaClassGenerator", "2.0.711.0")]
[Serializable]
[XmlType("CPtks", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class SelfServiceComplexProperties
{
    /// <summary>
    /// Податковий номер оператора ПТКС (64 символи).
    /// </summary>
    [MaxLength(64)]
    [XmlElement("SelfSeviceComplexPN", Form = XmlSchemaForm.Unqualified)]
    public string? SelfServiceComplexNumber { get; set; }

    /// <summary>
    /// Найменування оператора ПТКС (текст).
    /// </summary>
    [XmlElement("SelfSeviceComplexNM", Form = XmlSchemaForm.Unqualified)]
    public string? SelfServiceComplexName { get; set; }

    /// <summary>
    /// Податковий номер платіжної системи (64 символи).
    /// </summary>
    [MaxLength(64)]
    [XmlElement("PAYSYSTEMPN", Form = XmlSchemaForm.Unqualified)]
    public string? PaymentSystemTaxNumber { get; set; }

    /// <summary>
    /// Найменування платіжної системи (текст).
    /// </summary>
    [XmlElement("PAYSYSTEMNM", Form = XmlSchemaForm.Unqualified)]
    public string? PaymentSystemName { get; set; }

    /// <summary>
    /// Податковий номер еквайра торговця (64 символи).
    /// </summary>
    [MaxLength(64)]
    [XmlElement("ACQUIREPN", Form = XmlSchemaForm.Unqualified)]
    public string? AcquireTaxNumber { get; set; }

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
    public DateTimeColumn? PosTransactionDate { get; set; }

    /// <summary>
    /// POS-термінал. Номер чека транзакції (128 символів).
    /// </summary>
    [XmlElement("POSTRANSNUM", Form = XmlSchemaForm.Unqualified)]
    public Str128Column? PosTransactionNumber { get; set; }

    /// <summary>
    /// Ідентифікатор платіжного пристрою (128 символів).
    /// </summary>
    [MaxLength(128)]
    [XmlElement("DEVICEID", Form = XmlSchemaForm.Unqualified)]
    public string? DeviceId { get; set; }

    /// <summary>
    /// Реквізити електронного платіжного засобу (128 символів).
    /// </summary>
    [MaxLength(128)]
    [XmlElement("EPZDETAILS", Form = XmlSchemaForm.Unqualified)]
    public string? ElectronicPaymentDeviceDetails { get; set; }

    /// <summary>
    /// Код авторизації (64 символи)
    /// </summary>
    [MaxLength(64)]
    [XmlElement("AUTHCD", Form = XmlSchemaForm.Unqualified)]
    public string? AuthCode { get; set; }

    /// <summary>
    /// Номер терміналу ПТКС (64 символи).
    /// </summary>
    [MaxLength(64)]
    [XmlElement("TERMINALNUM", Form = XmlSchemaForm.Unqualified)]
    public string? TerminalNumber { get; set; }

    /// <summary>
    /// Адреса розміщення терміналу ПТКС (текст).
    /// </summary>
    [XmlElement("TERMINALADDR", Form = XmlSchemaForm.Unqualified)]
    public string? TerminalAddress { get; set; }

    /// <summary>
    /// Номер операції ПТКС (64 символи).
    /// </summary>
    [MaxLength(64)]
    [XmlElement("OPERNUM", Form = XmlSchemaForm.Unqualified)]
    public string? OperationNumber { get; set; }

    /// <summary>
    /// Номер операції у системі оператора ПТКС (64 символи).
    /// </summary>
    [MaxLength(64)]
    [XmlElement("OPERSYSNUM", Form = XmlSchemaForm.Unqualified)]
    public string? OperationSystemNumber { get; set; }

    /// <summary>
    /// Код банку (15 символів).
    /// </summary>
    [MaxLength(15)]
    [XmlElement("BANKCD", Form = XmlSchemaForm.Unqualified)]
    public string? BankCode { get; set; }

    /// <summary>
    /// Найменування банку отримувача, якщо присутній (текст).
    /// </summary>
    [XmlElement("BANKNM", Form = XmlSchemaForm.Unqualified)]
    public string? BankName { get; set; }
}