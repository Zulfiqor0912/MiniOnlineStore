using MiniOnlineStore.Models.User;

namespace MiniOnlineStore.Repository.Interface;

public interface IUserRepository
{
    public bool CreateUser(CreateUserDto createUserDto);
    public bool LoginUser(UserLoginDto loginDto);
}
