using MiniOnlineStore.Models.User;
using MiniOnlineStore.Repository.Interface;

namespace MiniOnlineStore.Repository;

public class UserRepository : IUserRepository
{
    public bool CreateUser(CreateUserDto createUserDto)
    {
        throw new NotImplementedException();
    }

    public bool LoginUser(UserLoginDto loginDto)
    {
        throw new NotImplementedException();
    }
}
