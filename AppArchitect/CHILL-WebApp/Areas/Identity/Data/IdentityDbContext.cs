using CHILL_WebApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CHILL_WebApp.Areas.Identity.Data;

public class IdentityDbContext : IdentityDbContext<IdentityUser>
{
    public IdentityDbContext()
    {
    }
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DS-Asus-Laptop\\SQLEXPRESS;Database=AppArchitectDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
        base.OnConfiguring(optionsBuilder);
    }
}