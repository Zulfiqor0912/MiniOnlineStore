using Microsoft.AspNetCore.Mvc;
using MiniOnlineStore.Models.User;
using MiniOnlineStore.Repository.Interface;

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
            return RedirectToAction("Login", "User");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(userDto);
        }
    }
}
