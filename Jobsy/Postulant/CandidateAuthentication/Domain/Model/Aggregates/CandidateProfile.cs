using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Jobsy.Postulant.CandidateAuthentication.Domain.Model.Commands;
using Jobsy.UserAuthentication.Domain.Model.Aggregates;

namespace Jobsy.Postulant.CandidateAuthentication.Domain.Model.Aggregates;

/// <summary>
///     This class represents the CandidateProfile aggregate. It stores candidate's profile information.
/// </summary>
public class CandidateProfile
{
    // Protected parameterless constructor for EF Core
    protected CandidateProfile()
    {
        Name = string.Empty;
        PublicationNumber = string.Empty;
        CV = string.Empty;
    }

    /// <summary>
    ///     Constructor using CreateCandidateProfileCommand
    /// </summary>
    /// <param name="command">The command used to create a candidate profile</param>
    public CandidateProfile(CreateCandidateProfileCommand command)
    {
        Name = command.Name;
        PublicationNumber = command.PublicationNumber;
        CV = command.CV;
        Posible = command.Posible;
        Id_Usuario = command.Id_Usuario;
    }

    public void Update(UpdateCandidateProfileCommand command)
    {
        Name = command.Name;
        PublicationNumber = command.PublicationNumber;
        CV = command.CV;
        Posible = command.Posible;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; private set; }

    [Required]
    [MaxLength(100)]
    public string PublicationNumber { get; private set; }

    [Required]
    [MaxLength(255)]
    public string CV { get; private set; }

    [Required]
    public bool Posible { get; private set; }

    // FK hacia User
    public int Id_Usuario { get; private set; }

    [ForeignKey("Id_Usuario")]
    public User user { get; private set; } = null!;
}