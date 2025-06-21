using AutoMapper;
using TaskManager.DataAccess.Entities;
using TaskManagerApi.Contracts.Users;

namespace TaskManagerApi.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserEntity, RegisterUserRequest>().ReverseMap();
            CreateMap<UserEntity, LoginUserRequest>();
        }
    }
}
