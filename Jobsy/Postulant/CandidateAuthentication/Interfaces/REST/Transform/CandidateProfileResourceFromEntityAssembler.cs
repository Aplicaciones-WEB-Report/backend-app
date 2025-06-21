using Jobsy.Postulant.CandidateAuthentication.Domain.Model.Aggregates;
using Jobsy.Postulant.CandidateAuthentication.Interfaces.REST.Resources;

namespace Jobsy.Postulant.CandidateAuthentication.Interfaces.REST.Transform;

/// <summary>
/// Assembles a CandidateProfileResource from a CandidateProfile entity.
/// </summary>
public static class CandidateProfileResourceFromEntityAssembler
{
    /// <summary>
    /// Converts a domain entity into a resource for response.
    /// </summary>
    /// <param name="entity">The CandidateProfile entity</param>
    /// <returns>The assembled CandidateProfileResource</returns>
    public static CandidateProfileResource ToResourceFromEntity(CandidateProfile entity) =>
        new(
            entity.Id,
            entity.Name,
            entity.PublicationNumber,
            entity.CV,
            entity.Posible,
            entity.Id_Usuario
        );
}