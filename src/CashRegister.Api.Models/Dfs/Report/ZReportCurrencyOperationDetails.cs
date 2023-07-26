using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CashRegister.Api.Models.Dfs.Report;

[GeneratedCode("XmlSchemaClassGenerator", "2.0.711.0")]
[Serializable]
[XmlType("ZValDetails", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class ZReportCurrencyOperationDetails
{
    [Required]
    [XmlElement("ROW", Form = XmlSchemaForm.Unqualified)]
    public Collection<CurrencyOperationsDetailsRow>? Rows { get; set; }
}