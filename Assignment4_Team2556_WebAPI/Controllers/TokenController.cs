using Assignment4_Team2556_WebAPI.Models.DTOModels;
using Assignment4_Team2556_WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Policy;

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

        [HttpGet("refresh")]
        //[ServiceFilter(typeof(ValidationFilterAttribute))] 
        public async Task<IActionResult> Refresh()
        {
            var refreshToken = Request.Cookies["Refresh-Token"];
            var accessToken = Request.Cookies["Access-Token"];
            if (refreshToken == null || accessToken == null) {
                return BadRequest();
            }
            else
            {
                //refreshToken = Request.Cookies["Refresh-Token"];
                var tokenDtoToReturn = await _service.RefreshToken(accessToken, refreshToken); //tokenDto
                //refreshToken = tokenDtoToReturn.RefreshToken;
                Response.Cookies.Append("Refresh-Token", tokenDtoToReturn.RefreshToken, new CookieOptions() { Secure = true, HttpOnly = true, SameSite = SameSiteMode.None });
                Response.Cookies.Append("Access-Token", tokenDtoToReturn.AccessToken, new CookieOptions() { Secure = true, HttpOnly = true, SameSite = SameSiteMode.None });
                return Ok(tokenDtoToReturn.AccessToken);
            }

        }


    }
}
