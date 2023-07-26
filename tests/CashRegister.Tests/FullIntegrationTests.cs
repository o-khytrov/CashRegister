using System.Net;
using System.Net.Http.Headers;
using System.Text;
using CashRegister.Api;
using CashRegister.Api.Models;
using CashRegister.Api.Models.Dfs.Responses.Enums;
using CashRegister.Api.Models.Dfs.Ticket;
using CashRegister.Api.Models.Requests;
using CashRegister.Api.Models.Responses;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace CashRegister.Tests;

public class SmokeTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    private readonly ITestOutputHelper _testOutputHelper;

    public SmokeTests(ITestOutputHelper output, WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
        _testOutputHelper = output;

        var username = Environment.GetEnvironmentVariable("Username") ??
                       throw new ArgumentException("username is not defined");
        var password = Environment.GetEnvironmentVariable("Password") ??
                       throw new ArgumentException("password is not defined");

        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme: "Basic",
            parameter: Convert.ToBase64String(Encoding.UTF8.GetBytes(username + ":" + password)));
    }

    [Fact]
    public async Task CheckFiscalServerStateTest()
    {
        var response = await GetAsync<ServerStateModel>("api/service/server_state");
        Assert.NotNull(response.Timestamp);
    }

    [Fact]
    public async Task GetBusinessUnitTest()
    {
        var businessUnitModels = await GetAsync<IEnumerable<BusinessUnitModel>>("/api/organization/business_units");
        Assert.NotEmpty(businessUnitModels);
    }

    [Fact]
    public async Task SaleInputOutputTest()
    {
        // Get Id of Cash Register
        var cashRegisterId = await GetCashRegisterId();

        await EnsureShiftIsOpen(cashRegisterId);

        var serviceIORequest = new ServiceIoRequest
        {
            CashRegisterId = cashRegisterId,
            Amount = 300
        };

        var serviceInputTicket =
            await PostAsync<ServiceIoRequest, TicketContent>("/api/service/input", serviceIORequest);
        Assert.NotNull(serviceInputTicket);
        var saleCheckTicket = await PostAsync<CheckModel, TicketContent>("/api/document/sale", TestData.TestCheckModel);
        Assert.NotNull(saleCheckTicket);

        await StronoCheck(cashRegisterId, saleCheckTicket.OrderTaxNum);

        var serviceOutputTicket =
            await PostAsync<ServiceIoRequest, TicketContent>("/api/service/output", serviceIORequest);
        Assert.NotNull(serviceOutputTicket);

        // Make Z-Report
        await ExecuteZReport(cashRegisterId);

        // Close Shift
        await CloseShift(cashRegisterId);
    }

    [Fact]
    public async Task ReturnTest()
    {
        // Get Id of Cash Register
        var cashRegisterId = await GetCashRegisterId();

        await EnsureShiftIsOpen(cashRegisterId);

        var saleCheckRequest = TestData.TestCheckModel2;

        var saleCheckTicket = await PostAsync<CheckModel, TicketContent>("/api/document/sale", saleCheckRequest);
        Assert.NotNull(saleCheckTicket);

        var moneyToReturn =
            saleCheckRequest.Rows?.Take(1).Sum(x => x.Amount * x.RetailPrice) ?? 0;

        var returnCheckRequest = new CheckModel
        {
            CashRegisterId = saleCheckRequest.CashRegisterId,
            Rows = saleCheckRequest.Rows?.Take(1).ToList(),
            Payments = new[]
            {
                new CheckPayment
                {
                    Form = saleCheckRequest.Payments.First()
                        .Form,
                    Sum = moneyToReturn,
                    Provided = moneyToReturn,
                }
            },
            OrderReturnNumber = saleCheckTicket.OrderTaxNum,
        };
        var returnCheckTicket = await PostAsync<CheckModel, TicketContent>("/api/document/return", returnCheckRequest);
        Assert.NotNull(returnCheckTicket);

        // Make Z-Report
        await ExecuteZReport(cashRegisterId);

        // Close Shift
        await CloseShift(cashRegisterId);
    }

    [Fact]
    public async Task TestCheckWithDiscount()
    {
        // Get Id of Cash Register
        var cashRegisterId = await GetCashRegisterId();

        await EnsureShiftIsOpen(cashRegisterId);

        var saleCheckRequest = TestData.TestCheckModel3;

        var saleCheckTicket = await PostAsync<CheckModel, TicketContent>("/api/document/sale", saleCheckRequest);
        Assert.NotNull(saleCheckTicket);

        // Make Z-Report
        await ExecuteZReport(cashRegisterId);

        // Close Shift
        await CloseShift(cashRegisterId);
    }

    private async Task EnsureShiftIsOpen(ulong cashRegisterId)
    {
        // Open a Shift
        var state = await GetRegisterState(cashRegisterId);
        if (state.ShiftState == ECashRegisterState.Closed)
        {
            await OpenShift(cashRegisterId);
        }
    }

    private async Task StronoCheck(ulong cashRegisterId, ulong fiscalNumber)
    {
        var request = new CheckModel()
        {
            OrderReturnNumber = fiscalNumber,
            CashRegisterId = cashRegisterId,
            Payments = new List<CheckPayment>()
        };
        var returnCheckTicket =
            await PostAsync<CheckModel, TicketContent>("/api/document/storno", request);
        Assert.NotNull(returnCheckTicket);
    }

    private async Task CloseShift(ulong cashRegisterId)
    {
        var closeShiftModel = new CloseShiftModel(cashRegisterId);
        var closeShiftTicket = await PostAsync<CloseShiftModel, TicketContent>("/api/shift/close", closeShiftModel);
        Assert.NotNull(closeShiftTicket);
    }

    private async Task ExecuteZReport(ulong cashRegisterId)
    {
        var zReportRequest = new CashRegisterRequest(cashRegisterId);
        var zReportTicket =
            await PostAsync<CashRegisterRequest, TicketContent>("/api/report/z", zReportRequest);
        Assert.NotNull(zReportTicket);
    }

    private async Task OpenShift(ulong cashRegisterId)
    {
        var openShiftRequest = new OpenShiftModel(cashRegisterId);
        var openShiftTicket = await PostAsync<OpenShiftModel, TicketContent>("/api/shift/open", openShiftRequest);
        Assert.NotNull(openShiftTicket);
    }

    private Task<CashRegisterStateResponseModel> GetRegisterState(ulong cashRegisterId)
    {
        var requestUri = $"api/service/cash_register_state?fiscalNumber={cashRegisterId}";
        return GetAsync<CashRegisterStateResponseModel>(requestUri);
    }

    private static StringContent ToJsonContent(object obj)
    {
        var json = JsonConvert.SerializeObject(obj);
        var content = new StringContent(content: json,
            encoding: Encoding.UTF8,
            mediaType: System.Net.Mime.MediaTypeNames.Application.Json);
        return content;
    }

    private async Task<ulong> GetCashRegisterId()
    {
        var businessUnits = await GetAsync<IEnumerable<BusinessUnitModel>>("/api/organization/business_units");
        var cashRegisterId = businessUnits.First().TransactionsRegistrars.First().NumFiscal;
        return cashRegisterId;
    }

    private async Task<T> GetAsync<T>(string url)
        where T : class
    {
        var httpResponseMessage = await _client.GetAsync(url);
        var responseContent = await EnsureSuccessStatusCode(httpResponseMessage);
        var responseModel = JsonConvert.DeserializeObject<ApiResponse<T>>(responseContent);
        Assert.NotNull(responseModel?.Result);

        Assert.NotNull(responseModel?.Result);
        if (responseModel?.Result is null)
        {
            throw new AggregateException("Response can not be null");
        }

        return responseModel.Result;
    }

    private async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest request)
        where TResponse : class
    {
        var httpResponseMessage = await _client.PostAsync(url,
            ToJsonContent(request ?? throw new ArgumentException("Request can not be null")));
        var responseContent = await EnsureSuccessStatusCode(httpResponseMessage);
        var responseModel = JsonConvert.DeserializeObject<ApiResponse<TResponse>>(responseContent);
        Assert.NotNull(responseModel?.Result);
        if (responseModel?.Result is null)
        {
            throw new AggregateException("Response can not be null");
        }

        return responseModel.Result;
    }

    private async Task<string> EnsureSuccessStatusCode(HttpResponseMessage httpResponseMessage)
    {
        var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
        if (!httpResponseMessage.IsSuccessStatusCode)
        {
            _testOutputHelper.WriteLine(responseContent);
        }

        Assert.Equal(HttpStatusCode.OK, httpResponseMessage.StatusCode);
        return responseContent;
    }
}