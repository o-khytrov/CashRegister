using CashRegister.Api.Models;
using CashRegister.Api.Models.Dfs.Check;
using CashRegister.Api.Models.Dfs.Enums;
using CashRegister.Api.Models.Requests;
using CashRegister.Models.Services;
using EPaymentForm = CashRegister.Api.Models.Dfs.Enums.EPaymentForm;

namespace CashRegister.Api.Services;

public class FluentCheckFactory :
    FluentCheckFactory.IFirstStage,
    FluentCheckFactory.IOperationSelectionStage,
    FluentCheckFactory.IThirdStage,
    FluentCheckFactory.IFinalStage

{
    public interface IFirstStage
    {
        public IOperationSelectionStage FillHeaderFromContext(WorkContext workContext);
    }

    public interface IOperationSelectionStage
    {
        IThirdStage ForSale(CheckModel checkModel);

        IThirdStage ForServiceDeposit(ServiceIoRequest checkModel);

        IThirdStage ForServiceIssue(ServiceIoRequest checkModel);

        IThirdStage ForOpeningShift();

        IThirdStage ForClosingShift();

        IThirdStage ForReturn(CheckModel request);
        
        IThirdStage ForReturnFromXmlCheck(string xml);

        IThirdStage ForStorno(ulong orderToCancelFiscalNumber);
    }

    public interface IThirdStage
    {
        public Check Build();
    }

    public interface IFinalStage
    {
    }

    private Check _check;

    private FluentCheckFactory()
    {
    }

    public IOperationSelectionStage FillHeaderFromContext(WorkContext workContext)
    {
        _check.CheckHead = CreateCheckHead(workContext);
        return this;
    }

    public IThirdStage ForSale(CheckModel checkModel)
    {
        _check.CheckHead.DocType = EDfsCheckDocumentType.SaleGoods;
        _check.CheckHead.DocSubType = EDfsCheckDocumentSubType.CheckGoods;
        _check.CheckPaymentRows = BuildPaymentRows(checkModel);
        _check.BodyRows = BuildBodyRows(checkModel);
        _check.CheckTotal = BuildCheckTotal();
        return this;
    }

    private CheckTotal BuildCheckTotal()
    {
        return new CheckTotal
        {
            Sum = _check.BodyRows?.Sum(x => x.Cost) ?? 0,
            DiscountSum = _check.BodyRows?.Sum(x => x.DiscountSum) ?? 0,
        };
    }

    public IThirdStage ForServiceDeposit(ServiceIoRequest checkModel)
    {
        _check.CheckHead.DocType = EDfsCheckDocumentType.SaleGoods;
        _check.CheckHead.DocSubType = EDfsCheckDocumentSubType.ServiceDeposit;
        _check.CheckTotal = new CheckTotal()
        {
            Sum = checkModel.Amount
        };
        return this;
    }

    public IThirdStage ForServiceIssue(ServiceIoRequest checkModel)
    {
        _check.CheckHead.DocType = EDfsCheckDocumentType.SaleGoods;
        _check.CheckHead.DocSubType = EDfsCheckDocumentSubType.ServiceIssue;
        _check.CheckTotal = new CheckTotal()
        {
            Sum = checkModel.Amount
        };
        return this;
    }

    public IThirdStage ForOpeningShift()
    {
        _check.CheckHead.DocType = EDfsCheckDocumentType.OpenShift;
        _check.CheckHead.DocSubType = EDfsCheckDocumentSubType.CheckGoods;
        return this;
    }

    public IThirdStage ForClosingShift()
    {
        _check.CheckHead.DocType = EDfsCheckDocumentType.CloseShift;
        _check.CheckHead.DocSubType = EDfsCheckDocumentSubType.CheckGoods;
        return this;
    }

    public IThirdStage ForReturn(CheckModel request)
    {
        _check.CheckHead.DocType = EDfsCheckDocumentType.SaleGoods;
        _check.CheckHead.DocSubType = EDfsCheckDocumentSubType.CheckReturn;
        _check.CheckHead.OrderReturnNumber = request.OrderReturnNumber;
        _check.CheckPaymentRows = BuildPaymentRows(request);
        _check.BodyRows = BuildBodyRows(request);
        _check.CheckTotal = BuildCheckTotal();
        return this;
    }

    public IThirdStage ForReturnFromXmlCheck(string xml)
    {
        _check.CheckHead.DocType = EDfsCheckDocumentType.SaleGoods;
        _check.CheckHead.DocSubType = EDfsCheckDocumentSubType.CheckReturn;

        var checkBase = XmlCheckParser.Parse(xml);
        _check.CheckHead.OrderReturnNumber = checkBase.Number;
        _check.CheckPaymentRows = BuildPaymentRows(checkBase);
        _check.BodyRows = BuildBodyRows(checkBase);
        _check.CheckTotal = BuildCheckTotal();
        return this;
    }

    public IThirdStage ForStorno(ulong orderToCancelFiscalNumber)
    {
        _check.CheckHead.DocType = EDfsCheckDocumentType.SaleGoods;
        _check.CheckHead.DocSubType = EDfsCheckDocumentSubType.CheckStorno;
        _check.CheckHead.OrderStornoNumber = orderToCancelFiscalNumber;
        return this;
    }

    public Check Build()
    {
        return _check;
    }

    public static IFirstStage CreateCheck()
    {
        return new FluentCheckFactory()
        {
            _check = new Check()
        };
    }

    private static readonly Dictionary<EPaymentForm, string> PaymentFormNames = new()
    {
        {
            EPaymentForm.Card, "КАРТКА"
        },
        {
            EPaymentForm.Cash, "ГОТІВКА"
        },
        {
            EPaymentForm.Credit, "КРЕДИТ"
        },
        {
            EPaymentForm.Prepayment, "ПОПЕРЕДНЯ ОПЛАТА"
        }
    };

    private static List<CheckPaymentRow> BuildPaymentRows(CheckModel request)
    {
        return request.Payments.Select((x, i) => new CheckPaymentRow
        {
            PaymentFormCode = x.Form,
            PaymentFormName = PaymentFormNames[x.Form],
            Sum = x.Sum,
            Provided = x.Provided,
            Remains = x.Remains,
            RowNumber = i + 1,
        }).ToList();
    }

    private static List<CheckBodyRow> BuildBodyRows(CheckModel request)
    {
        return request.Rows.Select((x, i) => new CheckBodyRow
        {
            Code = null,
            Barcode = null,
            Uktzed = null,
            Dkpp = null,
            Name = x.ItemName,
            Description = null,
            UnitCode = x.UnitCode,
            UnitName = null,
            Amount = x.Amount,
            Price = x.RetailPrice,
            Letters = null,
            Cost = x.Sum,
            RecipientName = null,
            RecipientIpn = null,
            BankCode = null,
            BankName = null,
            BankAccountNumber = null,
            PaymentDetails = null,
            PaymentPurpose = null,
            PayerName = null,
            PayerIpn = null,
            PayerPacNum = null,
            PayDetailsPayer = null,
            BasisPayment = null,
            PayOutType = null,
            UsageType = EUsageType.Presale,
            DiscountType = EDiscountType.Sum,
            SubTotal = x.Amount * x.RetailPrice,
            DiscountNumber = null,
            DiscountTax = null,
            DiscountPercent = null,
            DiscountSum = x.SumDelta,
            Comment = null,
            ExciseLabels = null,
            RowNumber = i + 1,
        }).ToList();
    }

    private static CheckHead CreateCheckHead(WorkContext workContext)
    {
        var checkHead = new CheckHead
        {
            DateTime = DateTime.Now,
            Uid = Guid.NewGuid(),
            Tin = workContext.BusinessUnit.Tin,
            Ipn = workContext.BusinessUnit.Ipn,
            OrganizationName = workContext.BusinessUnit.OrgName,
            PointName = workContext.BusinessUnit.Name,
            PointAddress = workContext.BusinessUnit.Address,
            OrderNumber = workContext.NextLocalDocumentNumber,
            CashRegisterLocalNumber = workContext.CashRegister.NumLocal,
            CashRegisterFiscalNumber = workContext.CashRegister.NumFiscal,
            OrderReturnNumber = null,
            OrderStornoNumber = null,
            OperationTypeNumber = null,
            Cashier = workContext.Cashier,
            LogoUrl = null,
            Comment = null,
            Version = 1,
            PreviousDocHash = null,
            Testing = workContext.Testing,
        };
        return checkHead;
    }
}