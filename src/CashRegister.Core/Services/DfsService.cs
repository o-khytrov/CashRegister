using System.Text;
using System.Text.RegularExpressions;
using CashRegister.Api.Models.Dfs.Check;
using CashRegister.Api.Models.Dfs.Report;
using CashRegister.Api.Models.Dfs.Requests;
using CashRegister.Api.Models.Dfs.Responses;
using CashRegister.Api.Models.Dfs.Responses.Entities;
using CashRegister.Api.Models.Dfs.Responses.Enums;
using CashRegister.Api.Models.Dfs.Ticket;
using CashRegister.Models.DbModels;
using Microsoft.Extensions.Caching.Memory;

namespace CashRegister.Models.Services;

public class DfsService
{
    private const string BusinessUnitsCacheKey = "business_units";
    private readonly DfsHttpClient _dfsHttpClient;

    private readonly IMemoryCache _memoryCache;

    private readonly Repository _repository;

    public DfsService(DfsHttpClient dfsHttpClient, Repository repository, IMemoryCache memoryCache)
    {
        _dfsHttpClient = dfsHttpClient;
        _repository = repository;
        _memoryCache = memoryCache;
    }

    /// <summary>
    ///    Отримання стану РРО.
    /// </summary>
    public async Task<CashRegisterStateResponse> CmdCashRegisterState(long numFiscal, UserKeyInfo userKeyInfo)
    {
        var sendData = new CashRegisterStateRequest();
        sendData.NumFiscal = numFiscal;
        return await _dfsHttpClient.PostSignedCommand<CashRegisterStateRequest, CashRegisterStateResponse>(sendData,
            userKeyInfo);
    }

    /// <summary>
    ///     X-Звіт.
    /// </summary>
    public async Task<LastShiftTotalsResponse> GetLastShiftTotals(ulong fiscalNumber, UserKeyInfo userKeyInfo)
    {
        var sendData = new LastShiftTotalsRequest
        {
            NumFiscal = fiscalNumber
        };
        return await _dfsHttpClient.PostSignedCommand<LastShiftTotalsRequest, LastShiftTotalsResponse>(sendData,
            userKeyInfo);
    }

    /// <summary>
    ///     Отримання списку господарських одиниць.
    /// </summary>
    public async Task<BusinessUnit[]> GetBusinessUnits(UserKeyInfo userKeyInfo)
    {
        if (_memoryCache.TryGetValue(BusinessUnitsCacheKey, out BusinessUnit[] businessUnits))
        {
            return businessUnits;
        }

        var response =
            await _dfsHttpClient.PostSignedCommand<BusinessUnitsRequest, BusinessUnitResponse>(
                new BusinessUnitsRequest(),
                userKeyInfo);
        _memoryCache.Set(BusinessUnitsCacheKey, response.TaxObjects, TimeSpan.FromHours(12));

        return response.TaxObjects;
    }

    /// <summary>
    ///     Запит переліку операторів (касирів) для суб’єкта господарювання.
    /// </summary>
    public async Task<Operator[]> GetOperators(UserKeyInfo userKeyInfo)
    {
        var response =
            await _dfsHttpClient.PostSignedCommand<OperatorsRequest, OperatorsResponse>(new OperatorsRequest(),
                userKeyInfo);
        return response.Operators;
    }

    public Task<ServerStateResponse> GetServerState()
    {
        return _dfsHttpClient.PostUnsignedCommand<ServerStateRequest, ServerStateResponse>(new ServerStateRequest());
    }

    public async Task<string> GetCheck(CheckRequest request, UserKeyInfo userKeyInfo)
    {
        var bytes = await _dfsHttpClient.ReadCommandAsBytes<CheckRequest, DocumentInfoByLocalNumberResponse>(request,
            userKeyInfo);
        var checkXml = ConvertToUtf8String(bytes);
        await _repository.UpdateCheckXml(request.NumFiscal, checkXml);
        return checkXml;
    }

    public async Task<DocumentInfoByLocalNumberResponse> GetLastFiscalNum(DocumentInfoByLocalNumberRequest request,
        UserKeyInfo userKeyInfo)
    {
        return await _dfsHttpClient
            .PostSignedCommand<DocumentInfoByLocalNumberRequest, DocumentInfoByLocalNumberResponse>(
                request, userKeyInfo);
    }

    public Task<TicketContent> SendZReport(ZReport zReport, UserKeyInfo userKeyInfo)
    {
        return PostReport(zReport, userKeyInfo);
    }

    public async Task<WorkContext> GetWorkContext(UserKeyInfo keyInfo, ulong cashRegisterId)
    {
        var businessUnits = await GetBusinessUnits(keyInfo);
        foreach (var businessUnit in businessUnits)
        {
            foreach (var cashRegister in businessUnit.TransactionsRegistrars)
            {
                if (cashRegister.NumFiscal == cashRegisterId)
                {
                    var lastLocalNumber = await _repository.GetLasGetLocalNumber(cashRegisterId);
                    if (lastLocalNumber == 0u)
                    {
                        var state = await CmdCashRegisterState((long) cashRegisterId, keyInfo);
                        lastLocalNumber = (ulong) state.NextLocalNum - 1;
                    }

                    return new WorkContext(businessUnit, cashRegister, lastLocalNumber + 1);
                }
            }
        }

        throw new ArgumentException("Business unit not found");
    }

    public async Task<TicketContent> SendRawXml(ulong cashRegisterId, string xml, UserKeyInfo userKeyInfo)
    {
        var requestData = ConvertTo1251Bytes(xml);
        var signedTicket = await _dfsHttpClient.PostXml(requestData, userKeyInfo);
        var ticketBytes = SignatureReader.DecryptSignedData(signedTicket);
        var ticketXml = ConvertToUtf8String(ticketBytes);
        var ticket = TicketContentExtensions.FromXmlString(ticketXml);
        var document = new Document
        {
            LocalNumber = ticket.OrderNum,
            FiscalNumber = ticket.OrderTaxNum.ToString(),
            CashRegisterId = cashRegisterId,
            Xml = ConvertToUtf8String(requestData),
            DocumentType = EDfsDocumentType.Check,
            Ticket = ticketXml
        };

        await _repository.InsertDocument(document);

        return ticket;
    }

    public async Task<TicketContent> SendCheck(Check check, UserKeyInfo userKeyInfo)
    {
        await using var stream = new MemoryStream();
        check.WriteXml(stream);
        var requestData = stream.ToArray();
        var signedTicket = await _dfsHttpClient.PostXml(requestData, userKeyInfo);
        var ticketBytes = SignatureReader.DecryptSignedData(signedTicket);
        var ticketXml = ConvertToUtf8String(ticketBytes);
        var ticket = TicketContentExtensions.FromXmlString(ticketXml);
        var document = new Document
        {
            LocalNumber = ticket.OrderNum,
            FiscalNumber = ticket.OrderTaxNum.ToString(),
            CashRegisterId = check.CheckHead.CashRegisterFiscalNumber,
            Xml = ConvertToUtf8String(requestData),
            DocumentType = EDfsDocumentType.Check,
            Ticket = ticketXml
        };

        await _repository.InsertDocument(document);

        return ticket;
    }

    private async Task<TicketContent> PostReport(ZReport zReport, UserKeyInfo userKeyInfo)
    {
        await using var stream = new MemoryStream();
        zReport.WriteXml(stream);
        var requestData = stream.ToArray();
        var signedTicket = await _dfsHttpClient.PostXml(requestData, userKeyInfo);
        var ticketBytes = SignatureReader.DecryptSignedData(signedTicket);
        var ticketXml = ConvertToUtf8String(ticketBytes);
        var ticket = TicketContentExtensions.FromXmlString(ticketXml);
        var document = new Document
        {
            LocalNumber = zReport.Header.OrderNumber,
            FiscalNumber = ticket.OrderTaxNum.ToString(),
            CashRegisterId = zReport.Header.CashRegisterFiscalNumber,
            Xml = ConvertToUtf8String(requestData),
            Ticket = ticketXml
        };

        await _repository.InsertDocument(document);

        return ticket;
    }

    public void SaveOfflineCheck(Check check)
    {
    }

    private byte[] ConvertTo1251Bytes(string str)
    {
        return Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding(1251), Encoding.UTF8.GetBytes(str));
    }

    private string ConvertToUtf8String(byte[] data)
    {
        var utf8Bytes = Encoding.Convert(Encoding.GetEncoding(1251), Encoding.UTF8, data);
        return Encoding.UTF8.GetString(utf8Bytes);
    }
}