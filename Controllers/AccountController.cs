using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiniOnlineStore.Models.Users;
using MiniOnlineStore.Repository.Interface;

namespace MiniOnlineStore.Controllers;

public class AccountController(ILogger<AccountController> logger,
    IUserRepository userRepository,
    SignInManager<User> signInManager) : Controller
{
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(CreateUserDto userDto)
    {
        if (!ModelState.IsValid)
            return View(userDto);
        try
        {
            await userRepository.CreateUser(userDto);
            TempData["SuccessMessage"] = "Ro‘yxatdan o‘tish muvaffaqiyatli amalga oshirildi!";
            return RedirectToAction("Login", "Account");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(userDto);
        }
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserLoginDto loginDto)
    {
        if (!ModelState.IsValid)
        {
            return View(loginDto);
        }

        var result = await signInManager.PasswordSignInAsync(
            loginDto.Username,
            loginDto.Password,
            isPersistent: false,
            lockoutOnFailure: false
            );
        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "Username yoki parol xato");
            return View(loginDto);
        }
        return RedirectToAction("Index", "Home");
    }

    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("Login", "Account");
    }
}
