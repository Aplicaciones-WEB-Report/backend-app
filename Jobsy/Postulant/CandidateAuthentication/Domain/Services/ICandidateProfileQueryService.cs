using Jobsy.Postulant.CandidateAuthentication.Domain.Model.Aggregates;
using Jobsy.Postulant.CandidateAuthentication.Domain.Model.Queries;

namespace Jobsy.Postulant.CandidateAuthentication.Domain.Services;

/// <summary>
///     Interface for querying candidate profiles.
/// </summary>
public interface ICandidateProfileQueryService
{
    /// <summary>
    ///     Handle the query to get all candidate profiles.
    /// </summary>
    /// <param name="query">GetAllCandidateProfilesQuery</param>
    /// <returns>List of CandidateProfile</returns>
    Task<IEnumerable<CandidateProfile>> Handle(GetAllCandidateProfilesQuery query);

    /// <summary>
    ///     Handle the query to get a candidate profile by ID.
    /// </summary>
    /// <param name="query">GetCandidateProfileByIdQuery</param>
    /// <returns>CandidateProfile if found, otherwise null</returns>
    Task<CandidateProfile?> Handle(GetCandidateProfileByIdQuery query);
}