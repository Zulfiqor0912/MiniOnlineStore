using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using MiniOnlineStore.Models.Products;
using MiniOnlineStore.Models.Users;

namespace MiniOnlineStore.Data;

public class MiniOnlineStoreDbContext : 
    IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public MiniOnlineStoreDbContext(DbContextOptions<MiniOnlineStoreDbContext> options)
            : base(options)
    {
    }
    DbSet<User> Users { get; set; }

    DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Product>()
            .HasOne(p => p.User)
            .WithMany(p => p.Products)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
