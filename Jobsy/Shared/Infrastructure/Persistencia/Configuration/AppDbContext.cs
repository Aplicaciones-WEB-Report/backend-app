using Jobsy.UserAuthentication.Domain.Model.Aggregates;
using Jobsy.Postulant.CandidateAuthentication.Domain.Model.Aggregates; 
using Jobsy.Recruiter.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Jobsy.Shared.Infrastructure.Persistencia.Configuration;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Usuarios { get; set; }
    public DbSet<CandidateProfile> CandidateProfiles { get; set; }
    public DbSet<EmployerProfile> EmployerProfiles { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>().HasKey(u => u.Id_Usuario);
        
        builder.Entity<User>()
            .HasOne<CandidateProfile>()
            .WithOne(cp => cp.user)
            .HasForeignKey<CandidateProfile>(cp => cp.Id_Usuario)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<User>()
            .HasOne(u => u.EmployerProfile)
            .WithOne(ep => ep.User)
            .HasForeignKey<EmployerProfile>(ep => ep.Id_Usuario)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
