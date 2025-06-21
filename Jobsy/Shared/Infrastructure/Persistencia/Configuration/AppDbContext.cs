using Jobsy.UserAuthentication.Domain.Model.Aggregates;
using Jobsy.UserAuthentication.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jobsy.Shared.Infrastructure.Persistencia.Configuration;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<User> Usuarios { get; set; }
    public DbSet<Profile> Perfiles { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Relación uno a uno entre User y Profile
        builder.Entity<User>()
            .HasOne<Profile>()
            .WithOne(p => p.user)
            .HasForeignKey<Profile>(p => p.Id_Usuario);
    }
}