using Assignment4_Team2556_WebAPI.Models.DTOModels;
using Microsoft.AspNetCore.Identity;

namespace Assignment4_Team2556_WebAPI.Services
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDTO userForRegistration);
        Task<bool> ValidateUser(UserForAuthenticationDTO userForAuth);
        Task<TokenDTO> CreateToken(bool populateExp);
        Task<TokenDTO> RefreshToken(TokenDTO tokenDTO);
    }
}
