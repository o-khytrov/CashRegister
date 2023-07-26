using CashRegister.Api.Models.Dfs.Report;
using CashRegister.Api.Models.Dfs.Responses;
using CashRegister.Api.Models.Dfs.Responses.Entities;
using CashRegister.Models.Services;

namespace CashRegister.Api.Services;

public class FluentZReportFactory :
    FluentZReportFactory.IBlankZReportStage,
    FluentZReportFactory.IFinalStage,
    FluentZReportFactory.IFillContentStage
{
    private ZReport _zReport;

    private FluentZReportFactory()
    {
    }

    public interface IBlankZReportStage
    {
        IFillContentStage FillHeaderFromContext(WorkContext workContext);
    }

    public interface IFillContentStage
    {
        IFinalStage FillContentFomXReport(LastShiftTotalsResponse xReport);

        ZReport Build();
    }

    public interface IFinalStage
    {
        ZReport Build();
    }

    public static IBlankZReportStage CreateZReport()
    {
        return new FluentZReportFactory
        {
            _zReport = new ZReport()
        };
    }

    public ZReport Build()
    {
        return _zReport;
    }

    public IFillContentStage FillHeaderFromContext(WorkContext workContext)
    {
        _zReport.Header = new ZReportHeader
        {
            Uid = Guid.NewGuid(),
            Tin = workContext.BusinessUnit.Tin,
            Ipn = null,
            OrganizationName = workContext.BusinessUnit.OrgName,
            PointName = workContext.BusinessUnit.Name,
            PointAddress = workContext.BusinessUnit.Address,
            DateTime = DateTime.Now,
            OrderNumber = workContext.NextLocalDocumentNumber,
            CashRegisterLocalNumber = workContext.CashRegister.NumLocal,
            CashRegisterFiscalNumber = workContext.CashRegister.NumFiscal,
            Cashier = workContext.Cashier,
            Testing = workContext.Testing
        };
        return this;
    }

    public IFinalStage FillContentFomXReport(LastShiftTotalsResponse xReport)
    {
        _zReport.SaleTotals = new ZReportSalesReturnTotals
        {
            PawnShopSumIssued = 0,
            PawnShopSumReceived = 0,
            RoundSum = 0,
            NoRoundSum = 0,
            OrdersCount = xReport.Totals?.Real?.OrdersCount ?? 0,
            TotalCurrencyCost = 0,
            TotalCurrencySum = 0,
            TotalCurrencyCommission = 0,
            Taxes = null,
        };
        if (xReport.Totals?.Real is not null)
        {
            _zReport.SaleTotals.OrdersCount = xReport.Totals.Real.OrdersCount;
            _zReport.SaleTotals.PaymentForms = GetPaymentFormsTotals(xReport.Totals.Real.PayForm.ToList());
            _zReport.SaleTotals.Sum = xReport.Totals.Real.Sum;
        }

        if (xReport.Totals?.Ret is not null)
        {
            _zReport.ReturnTotals = new ZReportSalesReturnTotals
            {
                Sum = xReport.Totals.Ret.Sum,
                OrdersCount = xReport.Totals.Ret.OrdersCount,
                PaymentForms = GetPaymentFormsTotals(xReport.Totals.Ret.PayForm)
            };
        }

        _zReport.GeneralTotals = new ZReportGeneralTotals()
        {
            ServiceInput = xReport.Totals?.ServiceInput ?? 0,
            ServiceOutput = xReport.Totals?.ServiceOutput ?? 0
        };
        return this;
    }

    private List<PaymentFormsTotals> GetPaymentFormsTotals(IEnumerable<ShiftTotalsPayForm> shiftTotalsPayForms)
    {
        return shiftTotalsPayForms.Select((x, i) => new PaymentFormsTotals
        {
            PaymentFormCode = x.PayFormCode,
            PaymentFormName = x.PayFormName,
            Sum = x.Sum,
            RowNumber = i + 1
        }).ToList();
    }
}