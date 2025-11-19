using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniOnlineStore.Models;
using MiniOnlineStore.Models.Products;
using MiniOnlineStore.Repository.Interface;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MiniOnlineStore.Controllers;

public class HomeController(
    IProductRepository productRepository,
    ILogger<HomeController> logger) : Controller
{


    [HttpGet]
    public async Task<IActionResult> GetAllProduct()
    { 
        var products = await productRepository.GetAllProductAsync();
        //Foydalanuvchi login qilganini tekshirish
        bool isAuthenticated = User.Identity != null && User.Identity.IsAuthenticated;
        Guid? userId = null;
        if (User.Identity != null && User.Identity.IsAuthenticated)
        {
            userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
        var model = products.Select(p => new Product
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Description = p.Description,
            ShowActions = isAuthenticated
        }).ToList();
        return View(model);
    }

    [Authorize]
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
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public async Task<IActionResult> UpdateProduct(Guid productId)
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var product = await productRepository.GetProductByIdAsync(productId, userId);

        if (product == null) return NotFound();

        var dto = new ProductDto
        {
            Name = product.Name,
            Price = product.Price,
            Description = product.Description
        };

        ViewData["ProductId"] = product.Id;
        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateProduct(Guid productId, ProductDto productDto)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors)
                                  .Select(e => e.ErrorMessage)
                                  .ToList();

            ViewBag.Errors = errors;
            return View(productDto);
        }

        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        await productRepository.UpdateProductAsync(productId, productDto);

        return RedirectToAction("GetAllProduct");
    }

    [HttpPost]
    public async Task<IActionResult> DeleteProduct(Guid productId)
    {
        await productRepository.DeleteProductAsync(productId);
        return RedirectToAction("GetAllProduct");
    }


    //[HttpPost]
    //public async Task<IActionResult> UpdateProduct(ProductDto dto)
    //{

    //}

    [AllowAnonymous]
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
