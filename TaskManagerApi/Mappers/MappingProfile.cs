using AutoMapper;
using TaskManager.DataAccess.Entities;
using TaskManagerApi.Contracts.Users;

namespace TaskManagerApi.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, RegisterUserRequest>().ReverseMap();
            CreateMap<User, LoginUserRequest>();
        }
    }
}
