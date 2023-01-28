using Assignment4_Team2556_WebAPI.Models.DTOModels;
using Assignment4_Team2556_WebAPI.Models;
using AutoMapper;

namespace Assignment4_Team2556_WebAPI.Data
{
    public class MappingProfile : Profile
    {
        //Used to automatically map DTO with the Model class
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDTO, User>();
        }
    }
}
