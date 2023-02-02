using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Assignment4_Team2556_WebAPI.Models.DTOModels
{
    public record TokenDTO(string AccessToken, string RefreshToken);
}
