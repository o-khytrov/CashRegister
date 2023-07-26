using CashRegister.Api.Models;
using CashRegister.Api.Models.Dfs.Ticket;
using CashRegister.Api.Services;
using CashRegister.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CashRegister.Api.Controllers;

[ApiController]
[Route("/api/shift/")]
[Authorize]
public class ShiftController : ControllerBase
{
    private readonly DfsService _dfsService;

    public ShiftController(DfsService dfsService)
    {
        _dfsService = dfsService;
    }

    /// <summary>
    ///     Відкриття зміни.
    /// </summary>
    [HttpPost("open")]
    public async Task<TicketContent> ShiftOpen([FromBody] OpenShiftModel request)
    {
        var userKeyInfo = this.GetKeyInfo();

        var context = await _dfsService.GetWorkContext(userKeyInfo, request.CashRegisterId);
        var check = FluentCheckFactory
            .CreateCheck()
            .FillHeaderFromContext(context)
            .ForOpeningShift()
            .Build();

        var ticket = await _dfsService.SendCheck(check, userKeyInfo);
        return ticket;
    }

    /// <summary>
    ///     Закриття зміни.
    /// </summary>
    [HttpPost("close")]
    public async Task<TicketContent> ShiftClose([FromBody] CloseShiftModel request)
    {
        var userKeyInfo = this.GetKeyInfo();
        var context = await _dfsService.GetWorkContext(userKeyInfo, request.CashRegisterId);
        var check = FluentCheckFactory
            .CreateCheck()
            .FillHeaderFromContext(context)
            .ForClosingShift()
            .Build();
        var ticket = await _dfsService.SendCheck(check, userKeyInfo);

        return ticket;
    }
}