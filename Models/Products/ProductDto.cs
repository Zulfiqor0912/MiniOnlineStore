namespace MiniOnlineStore.Models.Products;

public class ProductDto
{
    public string Name { get; set; }   // Mahsulot nomi
    public decimal Price { get; set; } // Narxi
    public int Quantity { get; set; }  // Soni (stock)
    public string Description { get; set; } // Qo‘shimcha izoh
    public string ImageUrl { get; set; } // Rasm linki (istalgancha)
}
