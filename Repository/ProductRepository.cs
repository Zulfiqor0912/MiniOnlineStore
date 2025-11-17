using AutoMapper;
using MiniOnlineStore.Data;
using MiniOnlineStore.Models.Products;
using MiniOnlineStore.Repository.Interface;

namespace MiniOnlineStore.Repository;

public class ProductRepository(
    MiniOnlineStoreDbContext dbContext,
    IMapper mapper,
    ILogger<ProductRepository> logger) : IProductRepository
{
    public async Task<bool> CreateProductAsync(ProductDto productDto)
    {
        try
        {
            if (productDto is null) new ArgumentNullException(nameof(productDto), "Maydonlarni to'ldiring");
            var product = mapper.Map<Product>(productDto);
            await dbContext.Products.

        }
    }

    public Task<bool> DeleteProductAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetAllProductAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateProductAsync(ProductDto productDto)
    {
        throw new NotImplementedException();
    }
}
