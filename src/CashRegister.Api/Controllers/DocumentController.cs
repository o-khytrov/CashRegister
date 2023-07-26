using CashRegister.Api.Models;
using CashRegister.Api.Models.Dfs.Requests;
using CashRegister.Api.Models.Dfs.Responses;
using CashRegister.Api.Models.Dfs.Ticket;
using CashRegister.Api.Services;
using CashRegister.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkiaSharp;
using SkiaSharp.QrCode;

namespace CashRegister.Api.Controllers;

public class BarcodeRenderer
{
    public BarcodeRenderer()
    {
    }

    public string RenderBarcode(string url)
    {
        using var generator = new QRCodeGenerator();

        var level = ECCLevel.H;
        var qr = generator.CreateQrCode(url, level);

        var info = new SKImageInfo(128, 128);
        using var surface = SKSurface.Create(info);

        var canvas = surface.Canvas;
        canvas.Render(qr, 128, 128, SKColors.Black, SKColors.Black, SKColors.White);

        using var image = surface.Snapshot();
        using var data = image.Encode(SKEncodedImageFormat.Png, 100);
        using var stream = new MemoryStream();
        data.SaveTo(stream);

        return "data:image/png;base64," + Convert.ToBase64String(stream.ToArray());
    }
}

[ApiController]
[Route("/api/document/")]
[Authorize]
public class DocumentController : ControllerBase
{
    private readonly DfsService _dfsService;
    private readonly PdfService _pdfService;
    private readonly IViewRenderService _viewRenderService;
    private readonly BarcodeRenderer _barcodeRenderer;

    public DocumentController(DfsService dfsService, PdfService pdfService, IViewRenderService viewRenderService)
    {
        _dfsService = dfsService;
        _pdfService = pdfService;
        _viewRenderService = viewRenderService;
        _barcodeRenderer = new BarcodeRenderer();
    }

    /// <summary>
    ///     Оримання інформації по документу.
    /// </summary>
    [HttpGet("xml")]
    public async Task<string> GetDocument([FromQuery] long fiscalNumber,
        long registerFiscalNumber)
    {
        var request = new CheckRequest
        {
            NumFiscal = fiscalNumber,
            RegistrarNumFiscal = registerFiscalNumber
        };

        var keyInfo = this.GetKeyInfo();
        return await _dfsService.GetCheck(request, keyInfo);
    }

    /// <summary>
    ///     Відправити XML документ 
    /// </summary>
    [HttpPost("xml")]
    public async Task<TicketContent> PostXml([FromQuery] string xml,
        ulong registerFiscalNumber)
    {
        var keyInfo = this.GetKeyInfo();
        return await _dfsService.SendRawXml(registerFiscalNumber, xml, keyInfo);
    }

    /// <summary>
    ///     Оримання інформації по документу.
    /// </summary>
    [HttpPost("info")]
    public async Task<DocumentInfoByLocalNumberResponse> GetDocumentInfo(DocumentInfoByLocalNumberRequest request)
    {
        var userKeyInfo = this.GetKeyInfo();
        return await _dfsService.GetLastFiscalNum(request, userKeyInfo);
    }

    /// <summary>
    ///     Оримання інформації по документу.
    /// </summary>
    [HttpGet("info_by_local_num")]
    public async Task<DocumentInfoByLocalNumberResponse> GetDocumentInfoByLocalNum([FromQuery] long localNumber,
        long registerFiscalNumber)
    {
        var request = new DocumentInfoByLocalNumberRequest
        {
            NumFiscal = registerFiscalNumber,
            NumLocal = localNumber
        };

        var userKeyInfo = this.GetKeyInfo();
        return await _dfsService.GetLastFiscalNum(request, userKeyInfo);
    }

    /// <summary>
    ///     Отправка чека.
    /// </summary>
    [HttpPost("sale")]
    public async Task<TicketContent> SendCheck([FromBody] CheckModel request)
    {
        var userKeyInfo = this.GetKeyInfo();
        var context = await _dfsService.GetWorkContext(userKeyInfo, request.CashRegisterId);
        var check = FluentCheckFactory
            .CreateCheck()
            .FillHeaderFromContext(context)
            .ForSale(request)
            .Build();
        var ticket = await _dfsService.SendCheck(check, userKeyInfo);
        return ticket;
    }

    /// <summary>
    ///     Повернення.
    /// </summary>
    [HttpPost("return")]
    public async Task<TicketContent> Return([FromBody] CheckModel request)
    {
        var userKeyInfo = this.GetKeyInfo();
        var context = await _dfsService.GetWorkContext(userKeyInfo, request.CashRegisterId);
        var check = FluentCheckFactory
            .CreateCheck()
            .FillHeaderFromContext(context)
            .ForReturn(request)
            .Build();
        var ticket = await _dfsService.SendCheck(check, userKeyInfo);
        return ticket;
    }

    /// <summary>
    /// Повернення на основі існуючого чеку
    /// </summary>
    [HttpPost("return-based")]
    public async Task<TicketContent> GenerateReturnFromExistingCheck([FromBody] StornoCheckRequest request)
    {
        var userKeyInfo = this.GetKeyInfo();
        var context = await _dfsService.GetWorkContext(userKeyInfo, request.RegistrarNumFiscal);
        var checkRequest = new CheckRequest
        {
            NumFiscal = (long) request.NumFiscal,
            RegistrarNumFiscal = (long) request.RegistrarNumFiscal
        };

        var keyInfo = this.GetKeyInfo();
        var xml = await _dfsService.GetCheck(checkRequest, keyInfo);

        var check = FluentCheckFactory
            .CreateCheck()
            .FillHeaderFromContext(context)
            .ForReturnFromXmlCheck(xml)
            .Build();
        var ticket = await _dfsService.SendCheck(check, userKeyInfo);
        return ticket;
    }

    /// <summary>
    ///     Відміна чека.
    /// </summary>
    [HttpPost("storno")]
    public async Task<TicketContent> Storno([FromBody] StornoCheckRequest request)
    {
        var userKeyInfo = this.GetKeyInfo();
        var context = await _dfsService.GetWorkContext(userKeyInfo, request.RegistrarNumFiscal);
        var check = FluentCheckFactory
            .CreateCheck()
            .FillHeaderFromContext(context)
            .ForStorno(request.NumFiscal)
            .Build();
        var ticket = await _dfsService.SendCheck(check, userKeyInfo);
        return ticket;
    }
}