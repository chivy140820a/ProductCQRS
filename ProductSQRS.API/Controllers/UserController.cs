using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductSQRS.API.SerVice;
using ProductSQRS.ViewModel.UserViewModel;
using System.Threading.Tasks;

namespace ProductSQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserSerVice _userSerVice;
        public UserController(IUserSerVice userSerVice)
        {
            _userSerVice = userSerVice;
        }
        [HttpGet("GetAllProduct")]
        public IActionResult GetAll()
        {
            return Ok();
        }
        [HttpPost("Authen")]
        public async Task<IActionResult> Authen([FromBody] AuthenticationRequest request)
        {
            var find = await _userSerVice.Authentication(request);
            return Ok(find);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm]RegisterRequest request)
        {
            var find = await _userSerVice.Register(request);
            return Ok();
        }    
    }
}
