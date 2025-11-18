using Microsoft.AspNetCore.Mvc;
using MiniOnlineStore.Models;
using MiniOnlineStore.Models.Products;
using MiniOnlineStore.Repository.Interface;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MiniOnlineStore.Controllers
{
    public class HomeController(
        IProductRepository productRepository,
        ILogger<HomeController> logger) : Controller
    {


        [HttpGet]
        public IActionResult GetAllProduct()
        { 
            return View();
        }

        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDto dto)
        {
            var claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList();
            if (!ModelState.IsValid) return View(dto);

            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdClaim))
            {
                // User login qilmagan, xatolik qaytarish
                return Unauthorized("Foydalanuvchi tizimga kirmagan");
            }
            var userId = Guid.Parse(userIdClaim);

            await productRepository.CreateProductAsync(dto, userId);
            return RedirectToAction("CreateProduct", "Index");
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
