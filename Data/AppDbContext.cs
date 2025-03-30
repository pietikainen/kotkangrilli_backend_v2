using kotkangrilli.Configurations;
namespace kotkangrilli.Data;

using Microsoft.EntityFrameworkCore;
using kotkangrilli.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Add DbSet for each entity
    public DbSet<User> Users { get; set; }

    // Configure entities
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}