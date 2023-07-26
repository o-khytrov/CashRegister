using System.Xml.Serialization;

namespace CashRegister.Api.Models.Dfs.Enums;

/// <summary>
///     Тип документа чек.
/// </summary>
[Serializable]
public enum EDfsCheckDocumentType
{
    /// <summary>
    ///     Чек реалізації товарів, послуг.
    /// </summary>
    [XmlEnum("0")]
    SaleGoods = 0,

    /// <summary>
    ///     Чек переказу коштів.
    /// </summary>
    [XmlEnum("1")]
    TransferFunds = 1,

    /// <summary>
    ///     Чек обміну валюти.
    /// </summary>
    /// 
    [XmlEnum("2")]
    CurrencyExchange = 2,

    /// <summary>
    ///     Чек видачі готівки.
    /// </summary>
    [XmlEnum("3")]
    CashWithdrawal = 3,

    /// <summary>
    ///     Відкриття зміни.
    /// </summary>
    [XmlEnum("100")]
    OpenShift = 100, // 0x00000064

    /// <summary>
    ///     Закриття зміни.
    /// </summary>
    [XmlEnum("101")]
    CloseShift = 101, // 0x00000065

    /// <summary>
    ///     Початок офлайн сесії.
    /// </summary>
    [XmlEnum("102")]
    OfflineBegin = 102, // 0x00000066

    /// <summary>
    ///     Завершення офлайн сесії.
    /// </summary>
    [XmlEnum("103")]
    OfflineEnd = 103 // 0x00000067
}