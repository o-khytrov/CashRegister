using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using CashRegister.Api.Models.Dfs.Extensions;

namespace CashRegister.Api.Models.Dfs.Report;

/// <summary>
/// Загальні підсумки.
/// </summary>
[GeneratedCode("XmlSchemaClassGenerator", "2.0.711.0")]
[Serializable]
[XmlType("ZBody", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class ZReportGeneralTotals
{
    /// <summary>
    /// Службове внесення//Отримання авансу/Отримання підкріплення (15.2 цифри).
    /// </summary>
    [RegularExpression("\\-{0,1}[0-9]+\\.[0-9]{2}")]
    [XmlElement("SERVICEINPUT", Form = XmlSchemaForm.Unqualified)]
    public decimal ServiceInput { get; set; }

    /// <summary>
    /// Службова видача/Інкасація (15.2 цифри).
    /// </summary>
    [RegularExpression("\\-{0,1}[0-9]+\\.[0-9]{2}")]
    [XmlElement("SERVICEOUTPUT", Form = XmlSchemaForm.Unqualified)]
    public decimal ServiceOutput { get; set; }

    /// <summary>
    /// Державний реєстраційний номер транспортного засобу (64 символи).
    /// </summary>
    [MaxLength(64)]
    [XmlElement("VEHICLERN", Form = XmlSchemaForm.Unqualified)]
    public string? VehicleNumber { get; set; }

    public void WriteXml(XmlTextWriter xmlTextWriter)
    {
        xmlTextWriter.WriteStartElement("ZREPBODY");
        xmlTextWriter.WriteElementD2("SERVICEINPUT", ServiceInput);
        xmlTextWriter.WriteElementD2("SERVICEOUTPUT", ServiceOutput);
        xmlTextWriter.WriteEndElement();
    }
}