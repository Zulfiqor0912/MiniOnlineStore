using MiniOnlineStore.Models.Users;

namespace MiniOnlineStore.Repository.Interface;

public interface IUserRepository
{
    Task<bool> CreateUser(CreateUserDto userDto);
    Task LoginUser(UserLoginDto loginDto);
}
