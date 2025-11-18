using MiniOnlineStore.Models.Products;

namespace MiniOnlineStore.Repository.Interface;

public interface IProductRepository
{
    Task<IEnumerable<ProductDto>> GetAllProductAsync();

    Task<bool> CreateProductAsync(ProductDto productDto, Guid userId);

    Task<bool> UpdateProductAsync(ProductDto productDto);
    Task<bool> DeleteProductAsync(Guid id);
}
