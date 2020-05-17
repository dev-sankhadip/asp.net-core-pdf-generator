using System.IO;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using PDF_Generator.Utility;

namespace PDF_Generator.Controllers
{
    [Route("api/pdf")]
    [ApiController]
    public class PDFCreatorController : ControllerBase
    {

        private IConverter converter;
        public PDFCreatorController(IConverter converter)
        {
            this.converter = converter;
        }

        // GET: api/PDFCreator
        [HttpGet]
        public IActionResult Get()
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = @"D:\pdf\Employee_Report.pdf"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = TemplateGenerator.GetHTMLString(),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            converter.Convert(pdf);

            return Ok("Successfully created PDF document.");
        }
    }
}
