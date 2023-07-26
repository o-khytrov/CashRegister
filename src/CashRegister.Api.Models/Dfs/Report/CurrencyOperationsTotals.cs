using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CashRegister.Api.Models.Dfs.Report;

/// <summary>
/// Підсумки операцій з іноземною валютою.
/// </summary>
[GeneratedCode("XmlSchemaClassGenerator", "2.0.711.0")]
[Serializable]
[XmlType("ZVal", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class CurrencyOperationsTotals
{
    /// <summary>
    /// Отримано авансів національною валютою (15.2 цифри).
    /// </summary>
    [RegularExpression("\\-{0,1}[0-9]+\\.[0-9]{2}")]
    [XmlElement("TOTALINADVANCE", Form = XmlSchemaForm.Unqualified)]
    public decimal TotalAdvanceNationalCurrency { get; set; }

    /// <summary>
    /// Отримано підкріплень національною валютою (15.2 цифри).
    /// </summary>
    [RegularExpression("\\-{0,1}[0-9]+\\.[0-9]{2}")]
    [XmlElement("TOTALINATTACH", Form = XmlSchemaForm.Unqualified)]
    public decimal TotalAttachmentsNationalCurrency { get; set; }

    /// <summary>
    /// Здано по інкасації національною валютою (15.2 цифри).
    /// </summary>
    [RegularExpression("\\-{0,1}[0-9]+\\.[0-9]{2}")]
    [XmlElement("TOTALSURRCOLLECTION", Form = XmlSchemaForm.Unqualified)]
    public decimal TotalSurrCollection { get; set; }

    /// <summary>
    /// Отримано комісії за операціями конвертації (15.2 цифри).
    /// </summary>
    [RegularExpression("\\-{0,1}[0-9]+\\.[0-9]{2}")]
    [XmlElement("COMMISSION", Form = XmlSchemaForm.Unqualified)]
    public decimal Commission { get; set; }

    /// <summary>
    /// Кількість розрахункових документів за зміну (числовий)-->
    /// </summary>
    [Required]
    [XmlElement("CALCDOCSCNT", Form = XmlSchemaForm.Unqualified)]
    public uint CalculationDocumentsCount { get; set; }

    /// <summary>
    /// Прийнято національної валюти для переказу (15.2 цифри).
    /// </summary>
    [RegularExpression("\\-{0,1}[0-9]+\\.[0-9]{2}")]
    [XmlElement("ACCEPTEDN", Form = XmlSchemaForm.Unqualified)]
    public decimal AcceptedNationalCurrency { get; set; }

    /// <summary>
    /// Видано національної валюти при виплаті переказу (15.2 цифри).
    /// </summary>
    [RegularExpression("\\-{0,1}[0-9]+\\.[0-9]{2}")]
    [XmlElement("ISSUEDN", Form = XmlSchemaForm.Unqualified)]
    public decimal IssuedNationalCurrency { get; set; }

    /// <summary>
    ///  Отримано комісії в національній валюті при здійсненні переказів (15.2 цифри).
    /// </summary>
    [RegularExpression("\\-{0,1}[0-9]+\\.[0-9]{2}")]
    [XmlElement("COMMISSIONN", Form = XmlSchemaForm.Unqualified)]
    public decimal CurrencyNationalCurrency { get; set; }

    /// <summary>
    /// Кількість операцій (документів) переказів або виплат переказів (числовий).
    /// </summary>
    [XmlElement("TRANSFERSCNT", Form = XmlSchemaForm.Unqualified)]
    public uint TransfersCount { get; set; }

    /// <summary>
    /// Підсумки по видам іноземної валюти.
    /// </summary>
    [XmlArray("DETAILS", Form = XmlSchemaForm.Unqualified)]
    [XmlArrayItem("ROW", Form = XmlSchemaForm.Unqualified)]
    public Collection<CurrencyOperationsDetailsRow>? Details { get; set; }

    /// <summary>
    /// Податки/Збори.
    /// </summary>
    [XmlArray("TAXES", Form = XmlSchemaForm.Unqualified)]
    [XmlArrayItem("ROW", Form = XmlSchemaForm.Unqualified)]
    public Collection<TaxTotals>? Taxes { get; set; }
}