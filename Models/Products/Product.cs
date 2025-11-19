using MiniOnlineStore.Models.Users;

namespace MiniOnlineStore.Models.Products;

public class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; }   // Mahsulot nomi

    public decimal Price { get; set; } // Narxi

    public int Quantity { get; set; }  // Soni (stock)

    public string Description { get; set; } // Qo‘shimcha izoh

    public string ImageUrl { get; set; } // Rasm linki (istalgancha)

    // Foreign key (User bilan bog‘lanish)
    public Guid UserId { get; set; }
    public User User { get; set; }
    public bool ShowActions { get; set; } = false;
}
