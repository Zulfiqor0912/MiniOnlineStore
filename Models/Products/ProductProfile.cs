using AutoMapper;

namespace MiniOnlineStore.Models.Products;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>();
    }
}
