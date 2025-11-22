using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiniOnlineStore.Data;
using MiniOnlineStore.Models.Products;
using MiniOnlineStore.Models;
using MiniOnlineStore.Repository.Interface;
using System.Security.Claims;
using MiniOnlineStore.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MiniOnlineStore.Repository;

public class ProductRepository(
    MiniOnlineStoreDbContext dbContext,
    IMapper mapper,
    ILogger<ProductRepository> logger) : IProductRepository
{
    public async Task<bool> CreateProductAsync(ProductDto productDto, Guid userId)
    {
        try
        {
            if (productDto is null) throw new ArgumentNullException(nameof(productDto), "Maydonlarni to'ldiring");
            var product = mapper.Map<Product>(productDto);
            product.UserId = userId;
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new ArgumentNullException("Nimadir xato ketdi");
        }
    }

    public async Task<bool> DeleteProductAsync(Guid id)
    {
        try
        {
            var product = await dbContext.Products.FindAsync(id);
            if (product is null) new ArgumentNullException(nameof(product), "Maydonlarni to'ldiring");
            var productDto = mapper.Map<ProductDto>(product);
            dbContext.Products.Remove(product!);
            await dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new ArgumentNullException("Nimadir xato ketdi");
        }
    }

    public async Task<IEnumerable<Product>> GetAllProductAsync()
    {
        var products = await dbContext.Products.ToListAsync();
        return products;
    }

    public async Task<Product> GetProductByIdAsync(Guid productId, Guid userId)
    {
        var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == productId && p.UserId == userId);
        return product!;
    }

    public async Task<IEnumerable<Product>> SearchProduct(string search)
    {
        var products = dbContext.Products.AsQueryable();
        if (!string.IsNullOrEmpty(search))
        {
            products = products.Where(p => p.Name.Contains(search));
        }

        
        return await products.ToListAsync();
    }

    public async Task<bool> UpdateProductAsync(Guid productId, ProductDto dto)
    {
        var oldProduct = await dbContext.Products.FindAsync(productId);

        if (oldProduct is null) throw new ArgumentNullException("Bunday mahsulot topilmadi");

        if (dto == null)
            throw new ArgumentException("Maydonlarni to'ldiring");

        oldProduct.Name = dto.Name;
        oldProduct.Description = dto.Description;
        oldProduct.Price = dto.Price;
        oldProduct.ImageUrl = dto.ImageUrl;
        oldProduct.Quantity = dto.Quantity;

        await dbContext.SaveChangesAsync();
        return true;
    }
}
