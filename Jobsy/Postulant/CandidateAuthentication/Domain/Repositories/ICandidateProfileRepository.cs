using Jobsy.Postulant.CandidateAuthentication.Domain.Model.Aggregates;
using Jobsy.Shared.Domain.Repositories;

namespace Jobsy.Postulant.CandidateAuthentication.Domain.Repositories;

/// <summary>
///     The candidate profile repository contract.
/// </summary>
public interface ICandidateProfileRepository : IBaseRepository<CandidateProfile>
{
    /// <summary>
    ///     Find candidate profile by user ID (foreign key: Id_Usuario).
    /// </summary>
    /// <param name="id_Usuario">The value of Id_Usuario</param>
    /// <returns>
    ///     The CandidateProfile object if found, or null otherwise.
    /// </returns>
    Task<CandidateProfile?> FindByUserIdAsync(int id_Usuario);
}