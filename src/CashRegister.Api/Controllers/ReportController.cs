using CashRegister.Api.Models.Dfs.Responses;
using CashRegister.Api.Models.Dfs.Ticket;
using CashRegister.Api.Models.Requests;
using CashRegister.Api.Services;
using CashRegister.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CashRegister.Api.Controllers;

[ApiController]
[Route("/api/report/")]
[Authorize]
public class ReportController : ControllerBase
{
    private readonly DfsService _dfsService;

    public ReportController(DfsService dfsService)
    {
        _dfsService = dfsService;
    }

    /// <summary>
    ///     X-звіт.
    /// </summary>
    [HttpGet("x")]
    public async Task<LastShiftTotalsResponse> ReportX(ulong fiscalNumber)
    {
        var keyInfo = this.GetKeyInfo();

        return await _dfsService.GetLastShiftTotals(fiscalNumber, keyInfo);
    }

    /// <summary>
    ///     Z-звіт.
    /// </summary>
    [HttpPost("z")]
    public async Task<TicketContent> ReportZ([FromBody] CashRegisterRequest request)
    {
        var keyInfo = this.GetKeyInfo();
        var context = await _dfsService.GetWorkContext(keyInfo, request.CashRegisterId);
        var xReport = await _dfsService.GetLastShiftTotals(request.CashRegisterId, keyInfo);
        var zReport = FluentZReportFactory.CreateZReport()
            .FillHeaderFromContext(context)
            .FillContentFomXReport(xReport)
            .Build();
        var ticket = await _dfsService.SendZReport(zReport, keyInfo);

        return ticket;
    }
}