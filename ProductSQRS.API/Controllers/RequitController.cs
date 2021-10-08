using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductSQRS.API.SerVice.RequitmentSV;
using System.Threading.Tasks;

namespace ProductSQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequitController : ControllerBase
    {
        private readonly IRequitmentSerVice _requitmentSerVice;
        public RequitController(IRequitmentSerVice requitmentSerVice)
        {
            _requitmentSerVice = requitmentSerVice;
        }
        [HttpPost("Author")]
        public async Task<IActionResult> Check([FromBody]string UserName)
        {
            var find = await _requitmentSerVice.Author(UserName);
            return Ok(find);
        }
    }
}
