using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductSQRS.API.SerVice.ExelSV;
using System.Threading.Tasks;

namespace ProductSQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly IExcelSerVice _excelSerVice;
        public ExcelController(IExcelSerVice excelSerVice)
        {
            _excelSerVice = excelSerVice;
        }
        public async Task<IActionResult> Create(string PathImage)
        {
            var excel = await _excelSerVice.ImportExcel(PathImage);
            return Ok(excel);
        }
    }
}
