using FastReport;
using FastReport.Export.PdfSimple;
using Microsoft.AspNetCore.Mvc;

namespace RelatorioFR.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]  
    public class RelatorioController : Controller
    {
        public RelatorioController() { }

        [HttpPost]
        [Route("RelatorioFr/GenerateReport")]
        public IActionResult GenerateReport()
        {
            
            Report report= new Report();
            
            var pdfExport = new PDFSimpleExport();
            using MemoryStream memoryStream = new MemoryStream();
            report.Prepare();
            report.Export(pdfExport, memoryStream);
            memoryStream.Flush();
            byte[] arrayRelatorio = memoryStream.ToArray();

            return File(memoryStream.ToArray(), "application/zip", "RelatorioSimples.pdf");
        }
    }
}
