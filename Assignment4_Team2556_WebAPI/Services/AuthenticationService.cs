using Assignment4_Team2556_WebAPI.Models;
using Assignment4_Team2556_WebAPI.Models.DTOModels;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Assignment4_Team2556_WebAPI.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        public AuthenticationService(IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
        {
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> RegisterUser(UserForRegistrationDTO userForRegistration)
        {
            var user = _mapper.Map<User>(userForRegistration); //maps the 'userForRegistrationDTO' to the 'User'' model
            var result = await _userManager.CreateAsync(user, userForRegistration.Password); //adds new user to the 'User' table in database
            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, userForRegistration.Roles); ////adds new 'user' and their 'role to the 'UserRoles' table in database
            }

            return result;
        }
    }
}
