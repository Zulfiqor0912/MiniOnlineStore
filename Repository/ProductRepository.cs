using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiniOnlineStore.Data;
using MiniOnlineStore.Models.Products;
using MiniOnlineStore.Models;
using MiniOnlineStore.Repository.Interface;
using System.Security.Claims;
using MiniOnlineStore.Models.Users;

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

    public async Task<IEnumerable<ProductDto>> GetAllProductAsync()
    {
        var products = await dbContext.Products.ToListAsync();
        var productsD = mapper.Map<List<ProductDto>>(products);
        return productsD;
    }

    public Task<bool> UpdateProductAsync(ProductDto productDto)
    {
        throw new NotImplementedException();
    }
}
