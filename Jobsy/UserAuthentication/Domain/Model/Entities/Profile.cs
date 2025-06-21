using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Jobsy.UserAuthentication.Domain.Model.Aggregates;


namespace Jobsy.UserAuthentication.Domain.Model.Entities;

public class Profile
{
    [Key]
    public int Id_Perfil { get; set; }

    [Required]
    public int Id_Usuario { get; set; }

    [ForeignKey("Id_Usuario")]
    public User user { get; set; }

    [StringLength(250)]
    public string Descripcion { get; set; }

    [StringLength(500)]
    public string Url_Foto { get; set; }

    //public Rol Rol { get; set; }  No va 
 
    
}