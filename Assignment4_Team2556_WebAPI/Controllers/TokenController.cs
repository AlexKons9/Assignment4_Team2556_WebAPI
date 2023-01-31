using Assignment4_Team2556_WebAPI.Models.DTOModels;
using Assignment4_Team2556_WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment4_Team2556_WebAPI.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticationService _service;

        public TokenController(IAuthenticationService service)
        {
            _service = service;
        }

        [HttpPost("refresh")]
        //[ServiceFilter(typeof(ValidationFilterAttribute))] 
        public async Task<IActionResult> Refresh([FromBody] TokenDTO tokenDto)
        {
            //if (!(Request.Cookies.TryGetValue("X-Refresh-Token", out var refreshToken)))
            //    return BadRequest();
            //tokenDto.RefreshToken = refreshToken;
            var cookie = Request.Cookies.TryGetValue("Refresh-Token", out var refreshToken);
            Console.WriteLine(cookie);

            var tokenDtoToReturn = await _service.RefreshToken(tokenDto);
            return Ok(tokenDtoToReturn);
        }


    }
}
