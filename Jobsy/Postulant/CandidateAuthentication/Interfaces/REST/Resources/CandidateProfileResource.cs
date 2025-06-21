namespace Jobsy.Postulant.CandidateAuthentication.Interfaces.REST.Resources;

/// <summary>
/// Represents the data provided by the server about a candidate profile.
/// </summary>
/// <param name="Id">Profile ID</param>
/// <param name="Name">Full name</param>
/// <param name="PublicationNumber">Publication number</param>
/// <param name="CV">CV file name</param>
/// <param name="Posible">True if active</param>
/// <param name="Id_Usuario">User ID (foreign key)</param>
public record CandidateProfileResource(
    int Id,
    string Name,
    string PublicationNumber,
    string CV,
    bool Posible,
    int Id_Usuario
);