using Microsoft.AspNetCore.Identity;

namespace MiniOnlineStore.Models.User;

public class User : IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
}
