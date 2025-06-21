using Jobsy.UserAuthentication.Domain.Model.Aggregates;
using Jobsy.Postulant.CandidateAuthentication.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Jobsy.Shared.Infrastructure.Persistencia.Configuration;

/// <summary>
/// Application's DB context.
/// </summary>
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // DbSets
    public DbSet<User> Usuarios { get; set; }
    public DbSet<CandidateProfile> CandidateProfiles { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Relación uno a uno entre User y CandidateProfile
        builder.Entity<User>()
            .HasOne<CandidateProfile>()
            .WithOne(cp => cp.user)
            .HasForeignKey<CandidateProfile>(cp => cp.Id_Usuario)
            .OnDelete(DeleteBehavior.Cascade); // Opcional: si quieres eliminar el perfil si se elimina el usuario
    }
}