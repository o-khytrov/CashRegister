using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CashRegister.Api.Models.Dfs.Check;

/// <summary>
/// Акцизна марка
/// </summary>
[GeneratedCode("XmlSchemaClassGenerator", "2.0.711.0")]
[Serializable]
[XmlType("CExciseLabels", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class CExciseLabels
{
    public CExciseLabels()
    {
        Rows = new List<ExciseLabel>();
    }

    [XmlElement("ROW", Form = XmlSchemaForm.Unqualified)]
    public List<ExciseLabel> Rows { get; set; }
}