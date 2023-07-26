using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;
using CashRegister.Api.Models.Dfs.Types;

namespace CashRegister.Api.Models.Dfs.Report;

[GeneratedCode("XmlSchemaClassGenerator", "2.0.711.0")]
[Serializable]
[XmlType("TROWSVAL", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class CurrencyOperationsDetailsRow
{
    /// <summary>
    /// Порядковий номер валюти (числовий).
    /// </summary>
    [XmlElement("VALNUM", Form = XmlSchemaForm.Unqualified)]
    public int CurrencyNumber { get; set; }

    /// <summary>
    /// Код валюти (числовий).
    /// </summary>
    [Required]
    [XmlElement("VALCD", Form = XmlSchemaForm.Unqualified)]
    public uint CurrencyCode { get; set; }

    /// <summary>
    /// Найменування іноземної валюти (текст).
    /// </summary>
    [Required]
    [XmlElement("VALSYMCD", Form = XmlSchemaForm.Unqualified)]
    public string? CurrencySymbolCode { get; set; }

    /// <summary>
    /// Найменування іноземної валюти (текст).
    /// </summary>
    [XmlElement("VALNM", Form = XmlSchemaForm.Unqualified)]
    public string? CurrencyName { get; set; }

    /// <summary>
    /// Курс купівлі (ХХХХ.ХХХХХХХХ) на момент закриття зміни або курс операцій у випадку зміни курсу (64 символи).
    /// </summary>
    [XmlElement("COURSEBUY", Form = XmlSchemaForm.Unqualified)]
    public decimal CourseBuy { get; set; }

    /// <summary>
    /// Курс продажу (ХХХХ.ХХХХХХХХ) на момент закриття зміни або курс операцій у випадку зміни курсу (64 символи).
    /// </summary>
    [XmlElement("COURSESELL", Form = XmlSchemaForm.Unqualified)]
    public decimal CourseSell { get; set; }

    /// <summary>
    /// Курс регулятора (ХХХХ.ХХХХХХХХ) (64 символи).
    /// </summary>
    [XmlElement("COURSEREG", Form = XmlSchemaForm.Unqualified)]
    public decimal CourseReg { get; set; }

    /// <summary>
    /// Загальна сума проданої іноземної валюти (15.2 цифри).
    /// </summary>
    [XmlElement("BUYVALI", Form = XmlSchemaForm.Unqualified)]
    public decimal BUYVALI { get; set; }

    [XmlElement("SELLVALI", Form = XmlSchemaForm.Unqualified)]
    public decimal SELLVALI { get; set; }

    [XmlElement("BUYVALN", Form = XmlSchemaForm.Unqualified)]
    public decimal BUYVALN { get; set; }

    [XmlElement("SELLVALN", Form = XmlSchemaForm.Unqualified)]
    public decimal SELLVALN { get; set; }

    [XmlElement("STORBUYVALI", Form = XmlSchemaForm.Unqualified)]
    public decimal STORBUYVALI { get; set; }

    [XmlElement("STORSELLVALI", Form = XmlSchemaForm.Unqualified)]
    public decimal STORSELLVALI { get; set; }

    [XmlElement("STORBUYVALN", Form = XmlSchemaForm.Unqualified)]
    public decimal STORBUYVALN { get; set; }

    [XmlElement("STORSELLVALN", Form = XmlSchemaForm.Unqualified)]
    public decimal STORSELLVALN { get; set; }

    [XmlElement("CINVALI", Form = XmlSchemaForm.Unqualified)]
    public decimal CINVALI { get; set; }

    [XmlElement("COUTVALI", Form = XmlSchemaForm.Unqualified)]
    public decimal COUTVALI { get; set; }

    [XmlElement("UNUSVALI", Form = XmlSchemaForm.Unqualified)]
    public decimal UNUSVALI { get; set; }

    [XmlElement("UNUSVALN", Form = XmlSchemaForm.Unqualified)]
    public decimal UNUSVALN { get; set; }

    [XmlElement("COMMISSION", Form = XmlSchemaForm.Unqualified)]
    public decimal COMMISSION { get; set; }

    [XmlElement("INADVANCE", Form = XmlSchemaForm.Unqualified)]
    public decimal INADVANCE { get; set; }

    [XmlElement("INATTACH", Form = XmlSchemaForm.Unqualified)]
    public decimal INATTACH { get; set; }

    [XmlElement("SURRCOLLECTION", Form = XmlSchemaForm.Unqualified)]
    public decimal SURRCOLLECTION { get; set; }

    [XmlElement("STORUNUSVALI", Form = XmlSchemaForm.Unqualified)]
    public decimal STORUNUSVALI { get; set; }

    [XmlElement("STORUNUSVALN", Form = XmlSchemaForm.Unqualified)]
    public decimal STORUNUSVALN { get; set; }

    [XmlElement("STORCINVALI", Form = XmlSchemaForm.Unqualified)]
    public decimal STORCINVALI { get; set; }

    [XmlElement("STORCOUTVALI", Form = XmlSchemaForm.Unqualified)]
    public decimal STORCOUTVALI { get; set; }

    [XmlElement("STORCOMMISSION", Form = XmlSchemaForm.Unqualified)]
    public decimal STORCOMMISSION { get; set; }

    [XmlElement("VALCRCD", Form = XmlSchemaForm.Unqualified)]
    public string VALCRCD { get; set; }

    [XmlElement("CROSSSYMCD", Form = XmlSchemaForm.Unqualified)]
    public Str64Column CROSSSYMCD { get; set; }

    [XmlElement("CROSSCOURSE", Form = XmlSchemaForm.Unqualified)]
    public string CROSSCOURSE { get; set; }

    [Range(typeof(int), "1", "999999")]
    [Required]
    [XmlAttribute("ROWNUM")]
    public int RowNumber { get; set; }
}