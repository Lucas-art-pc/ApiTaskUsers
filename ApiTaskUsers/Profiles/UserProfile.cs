using ApiTaskUsers.Data.Dtos.Users;
using ApiTaskUsers.Models;
using AutoMapper;
namespace ApiTaskUsers.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
        CreateMap<User, ReadUserDto>();
        CreateMap<ReadUserDto, User>();
        CreateMap<UpdateUserDto, User>();
    }
}
