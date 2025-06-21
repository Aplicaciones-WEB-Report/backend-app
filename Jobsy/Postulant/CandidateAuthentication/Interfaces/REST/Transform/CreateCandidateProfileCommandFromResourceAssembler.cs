using Jobsy.Postulant.CandidateAuthentication.Domain.Model.Commands;
using Jobsy.Postulant.CandidateAuthentication.Interfaces.REST.Resources;

namespace Jobsy.Postulant.CandidateAuthentication.Interfaces.REST.Transform;

/// <summary>
/// Assembles a CreateCandidateProfileCommand from a CreateCandidateProfileResource.
/// </summary>
public static class CreateCandidateProfileCommandFromResourceAssembler
{
    /// <summary>
    /// Converts a resource into a command.
    /// </summary>
    /// <param name="resource">The resource received in the request</param>
    /// <returns>A CreateCandidateProfileCommand</returns>
    public static CreateCandidateProfileCommand ToCommandFromResource(CreateCandidateProfileResource resource) =>
        new(
            resource.Name,
            resource.PublicationNumber,
            resource.CV,
            resource.Posible,
            resource.Id_Usuario
        );
}