using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CashRegister.Api.Models.Dfs.Ticket
{
    [GeneratedCode("XmlSchemaClassGenerator", "2.0.711.0")]
    [Serializable()]
    [XmlType("TicketContent", Namespace = "")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlRoot("TICKET", Namespace = "")]
    public class TicketContent
    {
        /// <summary>
        ///     Унікальний ідентифікатор документа (GUID, обов’язковий).
        /// </summary>
        [Required]
        [XmlElement("UID", Form = XmlSchemaForm.Unqualified)]
        public string? Uid { get; set; }

        /// <summary>
        ///     Дата операції (ddmmyyyy, обов’язковий).
        /// </summary>
        [Required]
        [XmlElement("ORDERDATE", Form = XmlSchemaForm.Unqualified)]
        public string? OrderDate { get; set; }

        /// <summary>
        ///     Час операції (hhmmss, обов’язковий).
        /// </summary>
        [Required]
        [XmlElement("ORDERTIME", Form = XmlSchemaForm.Unqualified)]
        public string? OrderTime { get; set; }

        /// <summary>
        ///     Локальний номер документа (128 символів, обов’язковий).
        /// </summary>
        [Required]
        [XmlElement("ORDERNUM", Form = XmlSchemaForm.Unqualified)]
        public ulong OrderNum { get; set; }

        /// <summary>
        ///     Фіскальний номер документа (128 символів, необов’язковий).
        /// </summary>
        [MaxLength(128)]
        [XmlElement("ORDERTAXNUM", Form = XmlSchemaForm.Unqualified)]
        public ulong OrderTaxNum { get; set; }

        /// <summary>
        ///     Ідентифікатор офлайн сесії(128 символів, необов’язковий).
        /// </summary>
        [XmlElement("OFFLINESESSIONID", Form = XmlSchemaForm.Unqualified)]
        public ulong OfflineSessionId { get; set; }

        /// <summary>
        ///     "Секретне число" для обчислення фіскального номера офлайн документа (128 символів, необов’язковий).
        /// </summary>
        [XmlElement("OFFLINESEED", Form = XmlSchemaForm.Unqualified)]
        public ulong OfflineSeed { get; set; }

        /// <summary>
        ///     Код помилки (Ціле число >= 0, необов’язковий).
        /// </summary>
        [XmlElement("ERRORCODE", Form = XmlSchemaForm.Unqualified)]
        public int ErrorCode { get; set; }

        /// <summary>
        ///     Текст помилки (текст, необов’язковий).
        /// </summary>
        [XmlElement("ERRORTEXT", Form = XmlSchemaForm.Unqualified)]
        public string? ErrorText { get; set; }

        /// <summary>
        ///     Версія формату документа (числовий, обов’язковий).
        /// </summary>
        [Required]
        [XmlElement("VER", Form = XmlSchemaForm.Unqualified)]
        public int Ver { get; set; }

        /// <summary>
        ///     Ознака тестового документу.
        /// </summary>
        [XmlElement("TESTING")]
        public bool Testing { get; set; }
    }
}