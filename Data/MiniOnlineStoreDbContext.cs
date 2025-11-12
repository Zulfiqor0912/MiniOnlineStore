using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using MiniOnlineStore.Models.User;

namespace MiniOnlineStore.Data;

public class MiniOnlineStoreDbContext : 
    IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public MiniOnlineStoreDbContext(DbContextOptions<MiniOnlineStoreDbContext> options)
            : base(options)
    {
    }
    DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
