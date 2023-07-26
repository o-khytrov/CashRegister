namespace CashRegister.Api.Models.Dfs.Enums;

public enum EPaymentForm
{
    Cash = 0,
    Card = 1,
    Prepayment = 2,
    Credit = 3
}

/// <summary>
///     Тип застосування знижки/націнки (числовий):
///     0–Попередній продаж,
///     1–Проміжний підсумок,
///     2–Спеціальна.
/// </summary>
public enum EUsageType : byte
{
    Presale = 0,

    IntermediateTotal = 1,

    Special = 2
}

public enum EDiscountType : byte
{
    Sum = 0,

    Percent = 1
}