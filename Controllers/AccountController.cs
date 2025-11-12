using Microsoft.AspNetCore.Mvc;
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
}
