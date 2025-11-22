using MiniOnlineStore.Models.Products;

namespace MiniOnlineStore.Repository.Interface;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProductAsync();

    Task<bool> CreateProductAsync(ProductDto productDto, Guid userId);

    Task<bool> UpdateProductAsync(Guid productId, ProductDto dto);
    Task<bool> DeleteProductAsync(Guid id);
    Task<Product> GetProductByIdAsync(Guid productId, Guid userId);
    Task<IEnumerable<Product>> SearchProduct(string search);
}
