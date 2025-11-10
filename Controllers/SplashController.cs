using Microsoft.AspNetCore.Mvc;

namespace MiniOnlineStore.Controllers;

public class SplashController(
    ILogger<SplashController> logger) : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
