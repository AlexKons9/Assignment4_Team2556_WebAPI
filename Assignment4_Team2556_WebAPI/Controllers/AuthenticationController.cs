using Assignment4_Team2556_WebAPI.Models.DTOModels;
using Assignment4_Team2556_WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace Assignment4_Team2556_WebAPI.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _service;

        public AuthenticationController(IAuthenticationService service)
        {
            _service = service;
        }

        [HttpPost]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDTO userForRegistration)
        {
            var result = await _service.RegisterUser(userForRegistration);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return StatusCode(201);
        }

        [HttpPost("login")]

        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDTO user)
        {
            if(!await _service.ValidateUser(user))
            {
                return Unauthorized();
            }

            var tokenDTO = await _service.CreateToken(populateExp: true);
            //var accessTokenDTO = tokenDTO.AccessToken;
            Response.Cookies.Append("Refresh-Token", tokenDTO.RefreshToken, new CookieOptions() { Secure = true, HttpOnly = true, SameSite = SameSiteMode.None }); //, SameSite = SameSiteMode.Strict
            Response.Cookies.Append("Access-Token", tokenDTO.AccessToken, new CookieOptions() { Secure = true, HttpOnly = true, SameSite = SameSiteMode.None }); //, SameSite = SameSiteMode.Strict
            Response.Cookies.Append("Username", user.UserName, new CookieOptions() { Secure = true, HttpOnly = true, SameSite = SameSiteMode.None }); //, SameSite = SameSiteMode.Strict
            return Ok(tokenDTO.AccessToken);
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            var userName = Request.Cookies["Username"];
            await _service.RemoveRefreshToken(userName);
            
            foreach (var cookie in HttpContext.Request.Cookies)
            {
                Response.Cookies.Delete(cookie.Key, new CookieOptions() { Secure = true, HttpOnly = true, SameSite = SameSiteMode.None });
            }

            return Ok();

        }

    }
}
