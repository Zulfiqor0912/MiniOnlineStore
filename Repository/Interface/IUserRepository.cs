using MiniOnlineStore.Models.User;

namespace MiniOnlineStore.Repository.Interface;

public interface IUserRepository
{
    Task<bool> CreateUser(CreateUserDto userDto);
    Task LoginUser(UserLoginDto loginDto);
}
