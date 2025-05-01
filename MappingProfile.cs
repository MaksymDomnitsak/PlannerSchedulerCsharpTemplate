using AutoMapper;
using PlannerScheduler.Models;
using PlannerScheduler.Dto;

namespace PlannerScheduler
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>(); //всі маппери тут

            CreateMap<CreateUserDto, User>();

            CreateMap<User, UserDto>();
        }
    }
}
