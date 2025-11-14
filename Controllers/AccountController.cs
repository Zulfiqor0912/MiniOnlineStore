using Microsoft.AspNetCore.Mvc;
using MiniOnlineStore.Models.User;
using MiniOnlineStore.Repository.Interface;
using Microsoft.AspNetCore.Http;

namespace MiniOnlineStore.Controllers;

public class AccountController(ILogger<AccountController> logger,
    IUserRepository userRepository) : Controller
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
        var token = await userRepository.LoginUser(loginDto);

        if (token == null)
        {
            ModelState.AddModelError("", "Username yoki Parol noto'g'ri");
            return View(loginDto);
        }
        HttpContext.Session.SetString("JwtToken", token);

        return RedirectToAction("Index", "Home");
    }
}
