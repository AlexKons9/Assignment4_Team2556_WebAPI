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

        //
        // Summary: Registers a new user, i,e. passes the data from the UserForRegistrationDTO into the database
        [HttpPost]
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


        //
        // Summary: Handles user login.  Validates user credentials.  Returns an access token.  Attaches cookies to the http response.
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDTO user) 
        {
            if(!await _service.ValidateUser(user)) //user validation
            {
                return Unauthorized();
            }

            var tokenDTO = await _service.CreateToken(populateExp: true); // get access and refresh tokens
            Response.Cookies.Append("Refresh-Token", tokenDTO.RefreshToken, new CookieOptions() { Secure = true, HttpOnly = true, SameSite = SameSiteMode.None });  //store refresh token in http-only cookie
            Response.Cookies.Append("Access-Token", tokenDTO.AccessToken, new CookieOptions() { Secure = true, HttpOnly = true, SameSite = SameSiteMode.None }); //store access token in http-only cookie
            Response.Cookies.Append("Username", user.UserName, new CookieOptions() { Secure = true, HttpOnly = true, SameSite = SameSiteMode.None }); //store username in http-only cookie
            return Ok(tokenDTO.AccessToken);  //return access token as the http response
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
