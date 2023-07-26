using System.Xml.Serialization;

namespace CashRegister.Api.Models.Dfs.Enums;

/// <summary>
///     Розширені типи документа.
/// </summary>
[Serializable]
public enum EDfsCheckDocumentSubType
{
    /// <summary>
    ///     Касовий чек реалізація).
    /// </summary>
    [XmlEnum("0")]
    CheckGoods = 0,

    /// <summary>
    ///     Видатковий чек повернення).
    /// </summary>
    [XmlEnum("1")]
    CheckReturn = 1,

    /// <summary>
    ///     Чек операції службове внесення»/«отримання авансу».
    /// </summary>
    [XmlEnum("2")]
    ServiceDeposit = 2,

    /// <summary>
    ///     Чек операції отримання підкріплення».
    /// </summary>
    [XmlEnum("3")]
    AdditionalDeposit = 3,

    /// <summary>
    ///     Чек операції службоваи вдача»/«інкасація».
    /// </summary>
    [XmlEnum("4")]
    ServiceIssue = 4,

    /// <summary>
    ///     Чек сторнування попереднього чека.
    /// </summary>
    [XmlEnum("5")]
    CheckStorno = 5
}