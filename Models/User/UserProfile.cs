using AutoMapper;

namespace MiniOnlineStore.Models.User;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
    }
}
