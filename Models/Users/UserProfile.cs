using AutoMapper;

namespace MiniOnlineStore.Models.Users;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
    }
}
