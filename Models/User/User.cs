using Microsoft.AspNetCore.Identity;

namespace MiniOnlineStore.Models.User;

public class User : IdentityUser<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }
}
