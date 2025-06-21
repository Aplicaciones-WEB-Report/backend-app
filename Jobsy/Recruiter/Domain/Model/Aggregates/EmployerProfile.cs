// Path: Jobsy/Recruiter/Domain/Model/Aggregates/EmployerProfile.cs
using Jobsy.Recruiter.Domain.Model.ValueObjects;
using Jobsy.UserAuthentication.Domain.Model.Aggregates;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobsy.Recruiter.Domain.Model.Aggregates
{
    public class EmployerProfile
    {
        // La clave primaria sigue la convención "Id" para esta entidad
        public int Id { get; set; }

        public string CompanyName { get; set; } = string.Empty;

        public CompanySize CompanySize { get; set; }

        public string? Website { get; set; }

        public string? Description { get; set; }

        // --- CAMBIO CLAVE ---
        // La clave foránea AHORA se llama "Id_Usuario" para coincidir
        // exactamente con la clave primaria de la clase User.
        public int Id_Usuario { get; set; }

        // La propiedad de navegación a la entidad User.
        // El atributo [ForeignKey] apunta a la propiedad "Id_Usuario" de esta misma clase.
        [ForeignKey("Id_Usuario")]
        public User User { get; set; } = null!;
    }
}