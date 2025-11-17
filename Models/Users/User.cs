using Microsoft.AspNetCore.Identity;
using MiniOnlineStore.Models.Products;

namespace MiniOnlineStore.Models.Users;

public class User : IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public ICollection<Product> Products { get; set; }
}
