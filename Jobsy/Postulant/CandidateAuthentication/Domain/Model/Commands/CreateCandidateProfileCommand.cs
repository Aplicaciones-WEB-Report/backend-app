namespace Jobsy.Postulant.CandidateAuthentication.Domain.Model.Commands;

/// <summary>
///     Command to create a candidate profile linked to a user.
/// </summary>
/// <param name="Name">Candidate's full name</param>
/// <param name="PublicationNumber">Associated publication number</param>
/// <param name="CV">Filename or URL of the CV</param>
/// <param name="Posible">Flag indicating if the profile is possible/allowed</param>
/// <param name="Id_Usuario">User foreign key</param>
public record CreateCandidateProfileCommand(
    string Name,
    string PublicationNumber,
    string CV,
    bool Posible,
    int Id_Usuario
);