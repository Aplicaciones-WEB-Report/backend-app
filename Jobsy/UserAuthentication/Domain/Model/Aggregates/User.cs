using System.ComponentModel.DataAnnotations;
using Jobsy.UserAuthentication.Domain.Model.ValueObjects;

namespace Jobsy.UserAuthentication.Domain.Model.Aggregates;

public class User
{
    [Key]
    public int Id_Usuario { get; set; }
    
    [Required]
    [StringLength(35)]
    public string Nombre { get; set; }
    
    [Required]
    [StringLength(40)]
    public string Apellido { get; set; }
    
    [Required]
    [Range(18, 80)]
    public int Edad { get; set; }
    
    [Required]
    public String Correo { get; set; }
    
    
    [Required(ErrorMessage = "La contraseña es obligatoria")]
    [StringLength(50, ErrorMessage = "La contraseña no puede tener más de 50 caracteres")]
    public string Contrasenia  { get; set; }
    
    public Rol rol { get; set; }
}