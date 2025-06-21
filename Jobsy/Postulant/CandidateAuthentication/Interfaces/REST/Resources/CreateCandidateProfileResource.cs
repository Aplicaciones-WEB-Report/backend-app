namespace Jobsy.Postulant.CandidateAuthentication.Interfaces.REST.Resources;

/// <summary>
/// Represents the data required to create a candidate profile.
/// </summary>
/// <param name="Name">Full name of the candidate</param>
/// <param name="PublicationNumber">Reference publication</param>
/// <param name="CV">File name of the candidate's CV</param>
/// <param name="Posible">Indicates if the profile is currently active/possible</param>
/// <param name="Id_Usuario">Foreign key to the User entity</param>
public record CreateCandidateProfileResource(
    string Name,
    string PublicationNumber,
    string CV,
    bool Posible,
    int Id_Usuario
);