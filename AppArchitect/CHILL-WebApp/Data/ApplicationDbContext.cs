using CHILL_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CHILL_WebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Photo>? Photos { get; set; }
        public DbSet<Label>? Labels { get; set; }
        public DbSet<Expert>? Experts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
