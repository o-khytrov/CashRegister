using DinkToPdf;
using DinkToPdf.Contracts;

namespace CashRegister.Api.Services;

public class PdfService
{
    private readonly IConverter _converter;

    public PdfService(IConverter converter)
    {
        _converter = converter;
    }

    public byte[] GenerateReceipt(string html)
    {
        var pages = new List<string>
        {
            html
        };

        var globalSettings = new GlobalSettings
        {
            ColorMode = ColorMode.Color,
            Orientation = Orientation.Portrait,
            PaperSize = new PechkinPaperSize("80mm", "105mm"),
            Margins = new MarginSettings
            {
                Top = 1.0, Bottom = 1.0, Left = 1.2, Right = 1.2
            },
            DocumentTitle = "PDF Receipt"
        };

        var objects = pages.Select(p => new ObjectSettings
        {
            PagesCount = true,
            HtmlContent = p,
            WebSettings =
            {
                DefaultEncoding = "utf-8"
            }
        });

        var pdf = new HtmlToPdfDocument
        {
            GlobalSettings = globalSettings
        };

        pdf.Objects.AddRange(objects);
        return _converter.Convert(pdf);
    }
}