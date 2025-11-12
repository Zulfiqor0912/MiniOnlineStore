using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MiniOnlineStore.Data;
using MiniOnlineStore.Models.User;
using MiniOnlineStore.Repository.Interface;
using System.Threading.Tasks;

namespace MiniOnlineStore.Repository;

public class UserRepository( 
   IMapper mapper,
   UserManager<User> userManager,
   ILogger<UserRepository> logger) : IUserRepository
{
    private const string Message = "Foydalanuvchi {Username} registratsiyadan o'tmadi: {Errors}";
    public async Task<bool> CreateUser(CreateUserDto userDto)
    {
        if (userDto == null) throw new ArgumentNullException(nameof(userDto));
        var user = mapper.Map<User>(userDto);

        if (user == null) throw new ArgumentNullException(nameof(user));
        var result =  await userManager.CreateAsync(user, user.Password);

        try
        {
            if (!result.Succeeded)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                logger.LogError(Message, user.Username);
                throw new Exception(errors);
            }
            logger.LogInformation("Muvaffaqqiyatli o'tdi");
            return true;
        }
        catch (Exception ex) 
        {
            logger.LogError(Message, ex);
            throw;
        }

    }

    public Task LoginUser(UserLoginDto loginDto)
    {
        throw new NotImplementedException();
    }
}
