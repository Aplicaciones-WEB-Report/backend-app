// Path: Jobsy/Recruiter/Infrastructure/Persistence/EntityConfigurations/EmployerProfileEntityTypeConfiguration.cs
using Jobsy.Recruiter.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jobsy.Recruiter.Infrastructure.Persistence.EntityConfigurations;

public class EmployerProfileEntityTypeConfiguration : IEntityTypeConfiguration<EmployerProfile>
{
    public void Configure(EntityTypeBuilder<EmployerProfile> builder)
    {
        // Nombre de la tabla
        builder.ToTable("EmployerProfile");
        
        // Clave primaria
        builder.HasKey(e => e.Id);

        // Configuración de las columnas (basado en tu ERD)
        builder.Property(e => e.Id).HasColumnName("id_employer");
        builder.Property(e => e.CompanyName).HasColumnName("company_name");
        builder.Property(e => e.Website).HasColumnName("website");
        builder.Property(e => e.Description).HasColumnName("description");
        
        // La clave foránea a User (que es de otro Bounded Context)
        builder.Property(e => e.Id_Usuario).HasColumnName("id_usuario");
        
        // Conversión del Enum a string
        builder.Property(e => e.CompanySize)
            .HasConversion<string>()
            .HasColumnName("tamanio_empresa");

        // Relación uno a uno con la entidad User del otro contexto
        builder.HasOne(ep => ep.User)
            .WithOne() // No especificamos la propiedad de navegación inversa para no depender de ella
            .HasForeignKey<EmployerProfile>(ep => ep.Id_Usuario);
    }
}