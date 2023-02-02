using System.ComponentModel.DataAnnotations;

namespace Assignment4_Team2556_WebAPI.Models.DTOModels
{
    public class UserForAuthenticationDTO
    {
        [Required(ErrorMessage = "User name is required")] 
        public string? UserName { get; init; }
        [Required(ErrorMessage = "Password name is required")] 
        public string? Password { get; init; }
    }
}
