using MiniOnlineStore.Models.Products;

namespace MiniOnlineStore.Repository.Interface;

public interface IProductRepository
{
    Task<Product> GetAllProductAsync();

    Task<bool> CreateProductAsync(ProductDto productDto);

    Task<bool> UpdateProductAsync(ProductDto productDto);
    Task<bool> DeleteProductAsync(Guid id);
}
