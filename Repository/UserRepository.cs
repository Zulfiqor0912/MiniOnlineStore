using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MiniOnlineStore.Data;
using MiniOnlineStore.Models.Users;
using MiniOnlineStore.Repository.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MiniOnlineStore.Repository;

public class UserRepository( 
   IMapper mapper,
   UserManager<User> userManager,
   SignInManager<User> signInManager,
   ILogger<UserRepository> logger,
   IConfiguration config) : IUserRepository
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
                logger.LogError(Message, user.UserName);
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

    public async Task LoginUser(UserLoginDto loginDto)
    {
        if (loginDto is null) throw new ArgumentNullException(nameof(loginDto));

        try
        {
            var user = await userManager.FindByNameAsync(loginDto.Username);
            if (user == null)
            {
                logger.LogWarning("Login xato: Foydalanuvchi toilmadi", loginDto.Username);
                throw new ApplicationException("Email yoki parol xato");
            }

            var result = await signInManager.PasswordSignInAsync(
                loginDto.Username, 
                loginDto.Password, 
                true, 
                false
                );

            if (!result.Succeeded)
                logger.LogWarning("Login xato: noto'g'ri parol {Email} ", loginDto.Username);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "");
            throw;
        }
    }
}
