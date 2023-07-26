using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using CashRegister.Api.Models.Dfs.Enums;
using CashRegister.Api.Models.Dfs.Extensions;
using CashRegister.Api.Models.Dfs.Types;

namespace CashRegister.Api.Models.Dfs.Check;

[GeneratedCode("XmlSchemaClassGenerator", "2.0.711.0")]
[Serializable]
[XmlType("TROWSBODY", Namespace = "")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class CheckBodyRow
{
    /// <summary>
    /// Внутрішній код товару (64 символи).
    /// </summary>
    [XmlElement("CODE", Form = XmlSchemaForm.Unqualified)]
    public Str64Column? Code { get; set; }

    /// <summary>
    /// Штриховий код товару (64 символи).
    /// </summary>
    [XmlElement("BARCODE", Form = XmlSchemaForm.Unqualified)]
    public Str64Column? Barcode { get; set; }

    /// <summary>
    /// Код товару згідно з УКТЗЕД(15 цифр).
    /// </summary>
    [XmlElement("UKTZED", Form = XmlSchemaForm.Unqualified)]
    public PositiveIntegerColumn? Uktzed { get; set; }

    /// <summary>
    /// Код послуги згідно з ДКПП (15 символів).
    /// </summary>
    [XmlElement("DKPP", Form = XmlSchemaForm.Unqualified)]
    public DKPPColumn? Dkpp { get; set; }

    /// <summary>
    /// Найменування товару, послуги або операції (текст).
    /// </summary>
    [XmlElement("NAME", Form = XmlSchemaForm.Unqualified)]
    public string? Name { get; set; }

    /// <summary>
    /// Опис товару, послуги або операції (текст).
    /// </summary>
    [XmlElement("DESCRIPTION", Form = XmlSchemaForm.Unqualified)]
    public string? Description { get; set; }

    /// <summary>
    /// Код одиниці виміру згідно класифікатора (5 цифр).
    /// </summary>
    [XmlElement("UNITCD", Form = XmlSchemaForm.Unqualified)]
    public int UnitCode { get; set; }

    /// <summary>
    /// Найменування одиниці виміру (64 символи).
    /// </summary>
    [XmlElement("UNITNM", Form = XmlSchemaForm.Unqualified)]
    public Str64Column? UnitName { get; set; }

    /// <summary>
    /// Кількість/об’єм товару (15.3 цифри).
    /// </summary>
    [XmlElement("AMOUNT", Form = XmlSchemaForm.Unqualified)]
    public decimal Amount { get; set; }

    /// <summary>
    /// Ціна за одиницю товару (15.2 цифри).
    /// </summary>
    [XmlElement("PRICE", Form = XmlSchemaForm.Unqualified)]
    public decimal Price { get; set; }

    /// <summary>
    /// Літерні позначення видів і ставок податків/зборів (15 символів).
    /// </summary>
    [XmlElement("LETTERS", Form = XmlSchemaForm.Unqualified)]
    public Str15Column? Letters { get; set; }

    /// <summary>
    /// Сума операції (15.2 цифри).
    /// </summary>
    [XmlElement("COST", Form = XmlSchemaForm.Unqualified)]
    public decimal Cost { get; set; }

    /// <summary>
    /// Найменування отримувача, якщо присутній (текст).
    /// </summary>
    [XmlElement("RECIPIENTNM", Form = XmlSchemaForm.Unqualified)]
    public string? RecipientName { get; set; }

    /// <summary>
    /// Код отримувача, якщо присутній (12 символів).
    /// </summary>
    [XmlElement("RECIPIENTIPN", Form = XmlSchemaForm.Unqualified)]
    public HIPNColumn0? RecipientIpn { get; set; }

    /// <summary>
    /// Код банку отримувача, якщо присутній (15 символів).
    /// </summary>
    [XmlElement("BANKCD", Form = XmlSchemaForm.Unqualified)]
    public Str15Column? BankCode { get; set; }

    /// <summary>
    /// Найменування банку отримувача, якщо присутній (текст).
    /// </summary>
    [XmlElement("BANKNM", Form = XmlSchemaForm.Unqualified)]
    public string? BankName { get; set; }

    /// <summary>
    /// Номер рахунку в банку отримувача, якщо присутній (64 символи).
    /// </summary>
    [XmlElement("BANKRS", Form = XmlSchemaForm.Unqualified)]
    public Str64Column? BankAccountNumber { get; set; }

    /// <summary>
    /// Реквізити платіжного засобу отримувача, якщо присутній (текст).
    /// </summary>
    [XmlElement("PAYDETAILS", Form = XmlSchemaForm.Unqualified)]
    public string? PaymentDetails { get; set; }

    /// <summary>
    /// Призначення платежу (отримувача) (128 символів).
    /// </summary>
    [XmlElement("PAYPURPOSE", Form = XmlSchemaForm.Unqualified)]
    public Str128Column? PaymentPurpose { get; set; }

    /// <summary>
    /// Найменування платника, якщо присутній (текст).
    /// </summary>
    [XmlElement("PAYERNM", Form = XmlSchemaForm.Unqualified)]
    public string? PayerName { get; set; }

    /// <summary>
    /// Ідентифікаційний код платника, якщо присутній (12 символів).
    /// </summary>
    [XmlElement("PAYERIPN", Form = XmlSchemaForm.Unqualified)]
    public HIPNColumn0? PayerIpn { get; set; }

    /// <summary>
    /// Номер договору платника, якщо присутній (текст).
    /// </summary>
    [XmlElement("PAYERPACTNUM", Form = XmlSchemaForm.Unqualified)]
    public string? PayerPacNum { get; set; }

    /// <summary>
    /// Реквізити платіжного засобу платника, якщо присутній (текст).
    /// </summary>
    [XmlElement("PAYDETAILSP", Form = XmlSchemaForm.Unqualified)]
    public string? PayDetailsPayer { get; set; }

    /// <summary>
    /// Підстава платежу платником, якщо присутній (текст).
    /// </summary>
    [XmlElement("BASISPAY", Form = XmlSchemaForm.Unqualified)]
    public string? BasisPayment { get; set; }

    /// <summary>
    /// Тип виплати (зазначається тільки для чеку повернення) (1 символ).
    /// </summary>
    [XmlElement("PAYOUTTYPE", Form = XmlSchemaForm.Unqualified)]
    public LetterColumn? PayOutType { get; set; }

    #region Fuel

    /// <summary>
    /// Номер замовлення на відпуск пального з паливно-роздавальної колонки (128 символів).
    /// </summary>
    [XmlElement("FUELORDERNUM", Form = XmlSchemaForm.Unqualified)]
    public Str128Column? FuelOrderNum { get; set; }

    /// <summary>
    /// Найменування одиниці виміру пального (текст)-->
    /// </summary>
    [XmlElement("FUELUNITNM", Form = XmlSchemaForm.Unqualified)]
    public string? FuelUnitTin { get; set; }

    /// <summary>
    /// Номер розхідного резервуару (64 символи)-->
    /// </summary>
    [XmlElement("FUELTANKNUM", Form = XmlSchemaForm.Unqualified)]
    public Str64Column? FuelTankNum { get; set; }

    /// <summary>
    /// Номер паливно-роздавальної колонки (64 символи).
    /// </summary>
    [XmlElement("FUELCOLUMNNUM", Form = XmlSchemaForm.Unqualified)]
    public Str64Column? FuelColumnNumber { get; set; }

    /// <summary>
    /// Номер крану паливно-роздавальної колонки (64 символи).
    /// </summary>
    [XmlElement("FUELFAUCETNUM", Form = XmlSchemaForm.Unqualified)]
    public Str64Column? FuelFaucetNumber { get; set; }

    /// <summary>
    /// Ознака продажу пального в режимі повірки.
    /// </summary>
    [XmlElement("FUELSALESIGN", Form = XmlSchemaForm.Unqualified)]
    public bool FuelSaleSign { get; set; }

    #endregion

    #region Currency

    /// <summary>
    /// Код валюти (числовий)
    /// </summary>
    [XmlElement("VALCD", Form = XmlSchemaForm.Unqualified)]
    public PositiveIntegerColumn? CurrencyCode { get; set; }

    /// <summary>
    /// Символьний код валюти (64 символів).
    /// </summary>
    [XmlElement("VALSYMCD", Form = XmlSchemaForm.Unqualified)]
    public Str64Column? CurrencySymbolCode { get; set; }

    /// <summary>
    /// Найменування валюти (текст).
    /// </summary>
    [XmlElement("VALNM", Form = XmlSchemaForm.Unqualified)]
    public string? CurrencyName { get; set; }

    /// <summary>
    /// Тип операції (1 символ):
    /// 0-Купівля; 1-Сторно купівлі; 2-Продаж; 3-Сторно продажу; 4-Зворотній обмін; 5-Конвертація; 6–Сторно зворотного обміну; 7–Сторно конвертації-->
    /// </summary>
    [XmlElement("VALOPERTYPE", Form = XmlSchemaForm.Unqualified)]
    public string? CurrencyOperationType { get; set; }

    /// <summary>
    /// Код валюти виданої (числовий).
    /// </summary>
    [XmlElement("VALOUTCD", Form = XmlSchemaForm.Unqualified)]
    public PositiveIntegerColumn? CurrencyOutCode { get; set; }

    /// <summary>
    /// Символьний код валюти виданої (64 символів).
    /// </summary>
    [XmlElement("VALOUTSYMCD", Form = XmlSchemaForm.Unqualified)]
    public Str64Column? CurrencyOutSymbolCode { get; set; }

    /// <summary>
    /// Найменування валюти виданої (текст).
    /// </summary>
    [XmlElement("VALOUTNM", Form = XmlSchemaForm.Unqualified)]
    public string? CurrencyOutName { get; set; }

    /// <summary>
    /// Курс операції (ХХХХ.ХХХХХХХХ).
    /// </summary>
    [XmlElement("VALCOURSE", Form = XmlSchemaForm.Unqualified)]
    public Decimal8Column_R? CurrencyCourse { get; set; }

    /// <summary>
    /// Дата та час встановлення курсу (присутній тільки для чеку-довідки) (ддммррррггххсс).
    /// </summary>
    [XmlElement("VALCOURSEDATE", Form = XmlSchemaForm.Unqualified)]
    public DateTimeColumn? CurrencyCourseDateTime { get; set; }

    /// <summary>
    /// Сума валюти по типу операції, вказаної у ‘VALOPERTYPE’ (іноземна валюта) (15.2 цифри).
    /// </summary>
    [XmlElement("VALFOREIGNSUM", Form = XmlSchemaForm.Unqualified)]
    public Decimal2Column? CurrencyForeignSum { get; set; }

    /// <summary>
    /// Сума валюти по типу операції, вказаної у ‘VALOPERTYPE’ (національна валюта) (15.2 цифри).
    /// </summary>
    [XmlElement("VALNATIONALSUM", Form = XmlSchemaForm.Unqualified)]
    public Decimal2Column? CurrencyNationSum { get; set; }

    /// <summary>
    /// Сума комісії конвертації (15.2 цифри).
    /// </summary>
    [XmlElement("VALCOMMISSION", Form = XmlSchemaForm.Unqualified)]
    public Decimal2Column? CurrencyCommission { get; set; }

    /// <summary>
    /// Кількість розрахункових документів по операції (присутній тільки для чеку-довідки) (5 цифр)-->
    /// </summary>
    [XmlElement("VALOPERCNT", Form = XmlSchemaForm.Unqualified)]
    public Num5Column? CurrencyOperationsCount { get; set; }

    /// <summary>
    /// Відмова від продажу.
    /// </summary>
    [XmlElement("VALREFUSESELL", Form = XmlSchemaForm.Unqualified)]
    public bool CurrencyRefusal { get; set; }

    #endregion

    /// <summary>
    /// Напрямок руху коштів: видано клієнту ломбарда (false)/одержано від клієнта ломбарда (true).
    /// </summary>
    [XmlElement("PWNDIR", Form = XmlSchemaForm.Unqualified)]
    public bool PawnShopDirection { get; set; }

    #region Discount

    /// <summary>
    /// Знижка/націнка
    /// Тип застосування знижки/націнки (числовий):
    /// 0–Попередній продаж, 1–Проміжний підсумок, 2–Спеціальна.
    /// </summary>

    [XmlElement("USAGETYPE", Form = XmlSchemaForm.Unqualified)]
    public EUsageType UsageType { get; set; }

    /// <summary>
    /// Тип знижки/націнки (числовий)
    /// </summary>
    [XmlElement("DISCOUNTTYPE", Form = XmlSchemaForm.Unqualified)]
    public EDiscountType DiscountType { get; set; }

    /// <summary>
    /// Проміжна сума чеку, на яку нараховується знижка/націнка (15.2 цифри).
    /// </summary>
    [XmlElement("SUBTOTAL", Form = XmlSchemaForm.Unqualified)]
    public decimal SubTotal { get; set; }

    /// <summary>
    /// Порядковий номер операції, до якої відноситься знижка/націнка. Присутній, якщо знижка/націнка стосується лише однієї операції. (числовий).
    /// </summary>
    [XmlElement("DISCOUNTNUM", Form = XmlSchemaForm.Unqualified)]
    public string? DiscountNumber { get; set; }

    /// <summary>
    /// Податок, якщо знижка/націнка стосується лише одного податку (1 символ).
    /// </summary>
    [XmlElement("DISCOUNTTAX", Form = XmlSchemaForm.Unqualified)]
    public decimal? DiscountTax { get; set; }

    /// <summary>
    /// Відсоток знижки/націнки, для відсоткових знижок/націнок (не зазначається при фіксованій сумі знижки/націнки) (15.2 цифри).
    /// </summary>
    [XmlElement("DISCOUNTPERCENT", Form = XmlSchemaForm.Unqualified)]
    public Decimal2Column? DiscountPercent { get; set; }

    /// <summary>
    /// Загальна сума знижки/націнки (15.2 цифри).
    /// </summary>
    [XmlElement("DISCOUNTSUM", Form = XmlSchemaForm.Unqualified)]
    public decimal? DiscountSum { get; set; }

    #endregion

    /// <summary>
    /// Коментар.
    /// </summary>
    [XmlElement("COMMENT", Form = XmlSchemaForm.Unqualified)]
    public string? Comment { get; set; }

    /// <summary>
    /// Акцизні марки.
    /// </summary>
    [XmlArray("EXCISELABELS", Form = XmlSchemaForm.Unqualified)]
    [XmlArrayItem("ROW", Form = XmlSchemaForm.Unqualified)]
    public List<ExciseLabel>? ExciseLabels { get; set; }

    [Range(typeof(int), "1", "999999")]
    [Required]
    [XmlAttribute("ROWNUM")]
    public int RowNumber { get; set; }

    public void WriteXml(XmlTextWriter wr)
    {
        wr.WriteStartElement("ROW");
        wr.WriteAttributeString("ROWNUM", RowNumber.ToString());
        wr.WriteElementNn("CODE", Code);
        wr.WriteElementNn("BARCODE", Barcode);
        wr.WriteElementNn("UKTZED", Uktzed);
        wr.WriteElementNn("DKPP", Dkpp);
        wr.WriteElementNn("NAME", Name);
        wr.WriteElementNn("UNITCD", UnitCode);
        wr.WriteElementNn("UNITNM", UnitName);
        wr.WriteElementD3NN("AMOUNT", Amount);
        wr.WriteElementD2NN("PRICE", Price);
        wr.WriteElement("LETTERS", Letters);
        wr.WriteElementD2NN("COST", SubTotal);

        /*
        <!--Тип знижки/націнки (числовий):
            0–Сумова, 1–Відсоткова-->
        <xs:element name="DISCOUNTTYPE" type="xs:nonNegativeInteger" minOccurs="0" maxOccurs="1"/>
        <!--Проміжна сума чеку, на яку нараховується знижка/націнка (15.2 цифри)-->
        <xs:element name="SUBTOTAL" type="Decimal2Column" minOccurs="0" maxOccurs="1"/>
        <!--Порядковий номер операції, до якої відноситься знижка/націнка. Присутній, якщо знижка/націнка стосується лише однієї операції. (числовий)-->
        <xs:element name="DISCOUNTNUM" type="xs:positiveInteger" minOccurs="0" maxOccurs="1"/>
        <!--Податок, якщо знижка/націнка стосується лише одного податку (1 символ)-->
        <xs:element name="DISCOUNTTAX" type="TaxColumn" minOccurs="0" maxOccurs="1"/>
        <!--Відсоток знижки/націнки, для відсоткових знижок/націнок (не зазначається при фіксованій сумі знижки/націнки) (15.2 цифри)-->
        <xs:element name="DISCOUNTPERCENT" type="Decimal2Column" minOccurs="0" maxOccurs="1"/>
        <!--Загальна сума знижки/націнки (15.2 цифри)-->
        <xs:element name="DISCOUNTSUM" type="Decimal2Column" minOccurs="0" maxOccurs="1"/>
        */
        wr.WriteElement("DISCOUNTTYPE", ((int)DiscountType).ToString());
        wr.WriteElementD2NN("SUBTOTAL", SubTotal);
        wr.WriteElementD2NN("DISCOUNTSUM", DiscountSum);

        wr.WriteEndElement();
    }
}