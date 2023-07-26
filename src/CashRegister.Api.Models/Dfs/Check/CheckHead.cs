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
[XmlType("CHead", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class CheckHead
{
    /// <summary>
    /// Тип документа (числовий):
    /// 0-Чек реалізації товарів/послуг, 1-Чек переказу коштів, 2–Чек операції обміну валюти, 3-Чек видачі готівки,
    /// 4-Чек обслуговування у ломбарді,
    /// 100-Відкриття зміни, 101-Закриття зміни, 102-Початок офлайн сесії, 103-Завершення офлайн сесії.
    /// </summary>
    [Required]
    [XmlElement("DOCTYPE", Form = XmlSchemaForm.Unqualified)]
    public EDfsCheckDocumentType DocType { get; set; }

    /// <summary>
    /// Розширений тип документа (числовий):
    /// 0-Касовий чек (реалізація), 1-Видатковий чек (повернення), 2-Чек операції «службове внесення»/«отримання авансу»,
    /// 3-Чек операції «отримання підкріплення», 4–Чек операції «службова видача»/«інкасація»,
    /// 5-Чек сторнування попереднього чека.
    /// </summary>
    [XmlElement("DOCSUBTYPE", Form = XmlSchemaForm.Unqualified)]
    public EDfsCheckDocumentSubType? DocSubType { get; set; }


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
    /// Адреса точки продажу (256 символів).
    /// </summary>
    [MaxLength(256)]
    [XmlElement("POINTADDR", Form = XmlSchemaForm.Unqualified)]
    public string? PointAddress { get; set; }

    /// <summary>
    /// Дата операції (ддммрррр).
    /// </summary>
    [MinLength(8)]
    [MaxLength(8)]
    [XmlElement("ORDERDATE", Form = XmlSchemaForm.Unqualified)]
    public string OrderDate => DateTime.ToString("ddMMyyyy");

    /// <summary>
    /// Час операції (ггххсс).
    /// </summary>
    [MinLength(6)]
    [MaxLength(6)]
    [Required]
    [XmlElement("ORDERTIME", Form = XmlSchemaForm.Unqualified)]
    public string OrderTime => DateTime.ToString("HHmmss");

    /// <summary>
    /// Локальний номер документа (числовий).
    /// </summary> [Required] [XmlElement("ORDERNUM", Form = XmlSchemaForm.Unqualified)]
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
    /// Фіскальний номер чека, для якого здійснюється повернення (зазначається тільки для чеків повернення) (128 символів).
    /// </summary>
    [MaxLength(128)]
    [XmlElement("ORDERRETNUM", Form = XmlSchemaForm.Unqualified)]
    public ulong? OrderReturnNumber { get; set; }

    /// <summary>
    /// Фіскальний номер чека, для якого здійснюється сторнування (зазначається тільки для чеків сторнування) (128 символів).
    /// </summary>
    [MaxLength(128)]
    [XmlElement("ORDERSTORNUM", Form = XmlSchemaForm.Unqualified)]
    public ulong? OrderStornoNumber { get; set; }

    /// <summary>
    /// Найменування типу операції (128 символів).
    /// </summary>
    [MaxLength(128)]
    [XmlElement("OPERTYPENM", Form = XmlSchemaForm.Unqualified)]
    public string? OperationTypeNumber { get; set; }

    /// <summary>
    /// Державний реєстраційний номер транспортного засобу (64 символи).
    /// </summary>
    [MaxLength(64)]
    [XmlElement("VEHICLERN", Form = XmlSchemaForm.Unqualified)]
    public string? VehicleNumber { get; set; }

    /// <summary>
    /// Ознака відкликання останнього онлайн документа через дублювання офлайн документом.
    /// </summary>
    [XmlElement("REVOKELASTONLINEDOC", Form = XmlSchemaForm.Unqualified)]
    public bool? RevokeLastOnlineDoc { get; set; }

    /// <summary>
    /// ПІБ касира (128 символів).
    /// </summary>
    [MaxLength(128)]
    [XmlElement("CASHIER", Form = XmlSchemaForm.Unqualified)]
    public string? Cashier { get; set; }

    /// <summary>
    /// Посилання на графічне зображення найменування або логотипу виробника (256 символів).
    /// </summary>
    [MaxLength(256)]
    [XmlElement("LOGOURL", Form = XmlSchemaForm.Unqualified)]
    public string? LogoUrl { get; set; }

    /// <summary>
    /// Коментар
    /// </summary>
    [XmlElement("COMMENT", Form = XmlSchemaForm.Unqualified)]
    public string? Comment { get; set; }

    /// <summary>
    /// Версія формату документа (числовий).
    /// </summary>
    [Required]
    [XmlElement("VER", Form = XmlSchemaForm.Unqualified)]
    public int Version { get; set; }

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
    public bool? Offline { get; set; }

    /// <summary>
    /// Геш попереднього документа в режимі офлайн (64 символи)
    /// </summary>
    [MaxLength(64)]
    [XmlElement("PREVDOCHASH", Form = XmlSchemaForm.Unqualified)]
    public string? PreviousDocHash { get; set; }

    /// <summary>
    /// Документ відкликано.
    /// </summary>
    [XmlElement("REVOKED", Form = XmlSchemaForm.Unqualified)]
    public bool? Revoked { get; set; }

    /// <summary>
    /// Документ сторновано.
    /// </summary>
    [XmlElement("STORNED", Form = XmlSchemaForm.Unqualified)]
    public bool? Storned { get; set; }

    /// <summary>
    /// Ознака тестового нефіскального документа.
    /// </summary>
    [XmlElement("TESTING", Form = XmlSchemaForm.Unqualified)]
    public bool Testing { get; set; }

    [XmlIgnore]
    public DateTime DateTime { get; set; }

    public bool ShouldSerializeRevoked()
    {
        return Revoked.HasValue;
    }

    public bool ShouldSerializeRevokeLastOnlineDoc()
    {
        return RevokeLastOnlineDoc.HasValue;
    }

    public bool ShouldSerializeStorned()
    {
        return Storned.HasValue;
    }

    public bool ShouldSerializeOffline()
    {
        return Offline.HasValue;
    }

    public bool ShouldSerializeDocSubType()
    {
        return DocSubType.HasValue;
    }

    public void WriteXml(XmlTextWriter wr)
    {
        wr.WriteStartElement("CHECKHEAD");
        switch (DocType)
        {
            case EDfsCheckDocumentType.SaleGoods:
                wr.WriteElement("DOCTYPE", 0);
                wr.WriteElement("DOCSUBTYPE", (int) DocSubType);
                break;
            case EDfsCheckDocumentType.CashWithdrawal:
                wr.WriteElement("DOCTYPE", 3);
                wr.WriteElement("DOCSUBTYPE", (int) DocSubType);
                break;
            case EDfsCheckDocumentType.OpenShift:
                wr.WriteElement("DOCTYPE", 100);
                break;
            case EDfsCheckDocumentType.CloseShift:
                wr.WriteElement("DOCTYPE", 101);
                break;
            case EDfsCheckDocumentType.OfflineBegin:
                wr.WriteElement("DOCTYPE", 102);
                break;
            case EDfsCheckDocumentType.OfflineEnd:
                wr.WriteElement("DOCTYPE", 103);
                break;
        }

        wr.WriteElement("UID", Uid);
        wr.WriteElement("TIN", Tin);
        wr.WriteElementNn("IPN", Ipn);
        wr.WriteElement("ORGNM", OrganizationName);
        wr.WriteElement("POINTNM", PointName);
        wr.WriteElement("POINTADDR", PointAddress);
        wr.WriteElement("ORDERDATE", OrderDate);
        wr.WriteElement("ORDERTIME", OrderTime);
        wr.WriteElement("ORDERNUM", OrderNumber);
        wr.WriteElement("CASHDESKNUM", CashRegisterLocalNumber);
        wr.WriteElement("CASHREGISTERNUM", CashRegisterFiscalNumber);
        if (DocType == EDfsCheckDocumentType.SaleGoods && DocSubType == EDfsCheckDocumentSubType.CheckReturn)
        {
            wr.WriteElement("ORDERRETNUM", OrderReturnNumber);
        }

        if (DocType == EDfsCheckDocumentType.SaleGoods && DocSubType == EDfsCheckDocumentSubType.CheckStorno)
        {
            wr.WriteElement("ORDERSTORNUM", OrderStornoNumber);
        }

        if (DocType == EDfsCheckDocumentType.OfflineBegin)
        {
            wr.WriteElement("REVOKELASTONLINEDOC", RevokeLastOnlineDoc.Value ? "true" : "false");
        }

        wr.WriteElement("CASHIER", Cashier);
        wr.WriteElement("LOGOURL", LogoUrl);
        wr.WriteElement("VER", Version);
        if (Testing)
        {
            wr.WriteElement("TESTING", Testing.ToString().ToLower());
        }

        if (!string.IsNullOrWhiteSpace(OrderTaxNumber))
        {
            wr.WriteElement("ORDERTAXNUM", OrderTaxNumber);
        }

        if (Offline.HasValue)
        {
            wr.WriteElement("OFFLINE", Offline.Value.ToString().ToLower());
            wr.WriteElementNn("PREVDOCHASH", PreviousDocHash);
        }

        wr.WriteEndElement();
    }
}