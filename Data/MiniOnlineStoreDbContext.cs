using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using MiniOnlineStore.Models.User;

namespace MiniOnlineStore.Data;

public class MiniOnlineStoreDbContext(DbContextOptions<MiniOnlineStoreDbContext> dbContextOptions) : 
    IdentityDbContext<User, IdentityRole<Guid>, Guid>(dbContextOptions)
{
    DbSet<User> Users { get; set; }
}
