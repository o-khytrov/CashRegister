using CashRegister.Api.Models;
using CashRegister.Api.Models.Dfs.Enums;
using CashRegister.Api.Models.Dfs.Responses.Entities;
using CashRegister.Models.Services;

namespace CashRegister.Tests;

public static class TestData
{
    public static WorkContext TestWorkContext = new(businessUnit: new BusinessUnit
        {
            // Fill actual data
        },
        new TransactionsRegistrarItem
        {
            NumFiscal = 1,
            NumLocal = 1,
            Name = "Касса",
            Closed = false
        },
        1);

    public static CheckModel TestCheckModel = new()
    {
        CashRegisterId = TestWorkContext.CashRegister.NumFiscal,
        Rows = new[]
        {
            new CheckRow
            {
                ItemName = "Цитрамон-Д таб. №6",
                RetailPrice = 13.03m,
                FinalPrice = 13.03m,
                Sum = 13.03m * 3,
                Amount = 3,
                UnitCode = 1
            },
            new CheckRow
            {
                ItemName = "Энтерожермина форте сусп5мл№10,",
                RetailPrice = 348.05m,
                FinalPrice = 348.05m,
                Sum = 348.05m,
                Amount = 1,
                UnitCode = 1
            },
            new CheckRow
            {
                ItemName = "Гиалера эмул.15мл стиках №20",
                RetailPrice = 299.40m,
                FinalPrice = 299.40m,
                Sum = 299.40m * 0.8m,
                Amount = 0.8m,
                UnitCode = 1
            }
        },
        Payments = new[]
        {
            new CheckPayment
            {
                Sum = 626.66m,
                Form = EPaymentForm.Card,
                Provided = 626.66m
            }
        }
    };

    public static CheckModel TestCheckModel2 = new()
    {
        CashRegisterId = TestWorkContext.CashRegister.NumFiscal,
        Rows = new[]
        {
            new CheckRow()
            {
                ItemName = "Сальбутамол аэр. 10мл 200доз\\Глаксо Вэллкам*",
                RetailPrice = 70,
                FinalPrice = 70,
                Sum = 70,
                Amount = 1,
                UnitCode = 1
            },
            new CheckRow()
            {
                ItemName = "Бинт н/с 5 x 10\\Укрвата*",
                RetailPrice = 5.35m,
                FinalPrice = 5.35m,
                Amount = 3,
                Sum = 5.35m * 3,
                UnitCode = 1
            }
        },
        Payments = new[]
        {
            new CheckPayment
            {
                Sum = 86.05m,
                Form = EPaymentForm.Cash,
                Provided = 100
            }
        }
    };

    public static CheckModel TestCheckModel3 = new()
    {
        CashRegisterId = TestWorkContext.CashRegister.NumFiscal,
        Rows = new[]
        {
            new CheckRow
            {
                ItemName = "Ко-пренеса табл. 8мг/2.5мг n90 (10х9)",
                Amount = 0.111m,
                RetailPrice = 525.30m,
                FinalPrice = 472.77m,
                Sum = 52.48m,
                UnitCode = 1,
                SumDelta = 5.83m,
                TaxSum = 3.4332710m
            },
            new CheckRow
            {
                ItemName = "Парацетамол капс. 0.5 №10*",
                Amount = 1,
                RetailPrice = 16.31m,
                FinalPrice = 16.31m,
                Sum = 16.31m,
                UnitCode = 1,
                SumDelta = 0m,
                TaxSum = 0
            },
            new CheckRow
            {
                ItemName = "Семлопин таб. 0.005 №28**",
                Amount = 0.5m,
                RetailPrice = 66.45m,
                FinalPrice = 66.12m,
                Sum = 32.56m,
                UnitCode = 1,
                SumDelta = 0.67m,
                TaxSum = 2.1300935m
            },
            new CheckRow
            {
                ItemName = "Печаевские таб. от изжоги N 20 б/ сах",
                Amount = 1,
                RetailPrice = 39.05m,
                FinalPrice = 39.05m,
                Sum = 39.05m,
                UnitCode = 1,
                SumDelta = 0m,
                TaxSum = 6.5083333m
            }
        },
        Payments = new[]
        {
            new CheckPayment
            {
                Sum = 140.40m,
                Form = EPaymentForm.Card,
                Provided = 140.40m
            }
        }
    };
}