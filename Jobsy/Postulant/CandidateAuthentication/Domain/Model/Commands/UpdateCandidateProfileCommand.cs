namespace Jobsy.Postulant.CandidateAuthentication.Domain.Model.Commands;

/// <summary>
/// Command to update an existing candidate profile.
/// </summary>
public record UpdateCandidateProfileCommand(
    int Id,
    string Name,
    string PublicationNumber,
    string CV,
    bool Posible
);