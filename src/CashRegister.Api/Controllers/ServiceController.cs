using CashRegister.Api.Models.Dfs.Responses;
using CashRegister.Api.Models.Dfs.Ticket;
using CashRegister.Api.Models.Requests;
using CashRegister.Api.Models.Responses;
using CashRegister.Api.Services;
using CashRegister.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CashRegister.Api.Controllers;

[ApiController]
[Route("/api/service/")]
[Authorize]
public class ServiceController : ControllerBase
{
    private readonly DfsService _dfsService;

    public ServiceController(DfsService dfsService)
    {
        _dfsService = dfsService;
    }

    /// <summary>
    ///     Чек операції службове внесення»/«отримання авансу».
    /// </summary>
    [HttpPost("input")]
    public async Task<TicketContent> ServiceInput([FromBody] ServiceIoRequest request)
    {
        var keyInfo = this.GetKeyInfo();

        var context = await _dfsService.GetWorkContext(keyInfo, request.CashRegisterId);
        var check = FluentCheckFactory
            .CreateCheck()
            .FillHeaderFromContext(context)
            .ForServiceDeposit(request)
            .Build();
        return await _dfsService.SendCheck(check, keyInfo);
    }

    /// <summary>
    ///     Чек операції службоваи вдача»/«інкасація».
    /// </summary>
    [HttpPost("output")]
    public async Task<TicketContent> ServiceOutput([FromBody] ServiceIoRequest request)
    {
        var keyInfo = this.GetKeyInfo();
        var context = await _dfsService.GetWorkContext(keyInfo, request.CashRegisterId);
        var check = FluentCheckFactory
            .CreateCheck()
            .FillHeaderFromContext(context)
            .ForServiceIssue(request)
            .Build();
        return await _dfsService.SendCheck(check, keyInfo);
    }

    /// <summary>
    ///     Оримання стану фіскального реєстратора.
    /// </summary>
    [HttpGet("cash_register_state")]
    public async Task<CashRegisterStateResponseModel> GetCashRegisterState(long fiscalNumber)
    {
        var keyInfo = this.GetKeyInfo();
        var state = await _dfsService.CmdCashRegisterState(fiscalNumber, keyInfo);
        return BuildCashRegisterStateModel(state);
    }

    /// <summary>
    /// Перевірка фіскального серверу.
    /// </summary>
    [HttpGet("server_state")]
    [AllowAnonymous]
    public async Task<ServerStateModel> Ping()
    {
        var state = await _dfsService.GetServerState();
        return new ServerStateModel
            { Timestamp = state.Timestamp };
    }

    private CashRegisterStateResponseModel BuildCashRegisterStateModel(
        CashRegisterStateResponse cashRegisterStateResponse) =>
        new()
        {
            ShiftState = cashRegisterStateResponse.ShiftState,
            ShiftId = cashRegisterStateResponse.ShiftId,
            OpenShiftFiscalNum = cashRegisterStateResponse.OpenShiftFiscalNum,
            ZRepPresent = cashRegisterStateResponse.ZRepPresent,
            Name = cashRegisterStateResponse.Name,
            SubjectKeyId = cashRegisterStateResponse.SubjectKeyId,
            FirstLocalNum = cashRegisterStateResponse.FirstLocalNum,
            NextLocalNum = cashRegisterStateResponse.NextLocalNum,
            LastFiscalNum = cashRegisterStateResponse.LastFiscalNum,
            OfflineSupported = cashRegisterStateResponse.OfflineSupported,
            ChiefCashier = cashRegisterStateResponse.ChiefCashier,
            NextLocalNumForSend = cashRegisterStateResponse.NextLocalNum,
            OfflineSessionId = cashRegisterStateResponse.OfflineSessionId,
            OfflineSeed = cashRegisterStateResponse.OfflineSeed,
            OfflineNextLocalNum = cashRegisterStateResponse.OfflineNextLocalNum,
            OfflineSessionDuration = cashRegisterStateResponse.OfflineSessionDuration,
            OfflineSessionsMonthlyDuration = cashRegisterStateResponse.OfflineSessionsMonthlyDuration
        };
}