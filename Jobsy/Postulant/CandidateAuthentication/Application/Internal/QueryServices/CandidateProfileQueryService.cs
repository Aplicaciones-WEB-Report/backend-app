using Jobsy.Postulant.CandidateAuthentication.Domain.Model.Aggregates;
using Jobsy.Postulant.CandidateAuthentication.Domain.Model.Queries;
using Jobsy.Postulant.CandidateAuthentication.Domain.Repositories;
using Jobsy.Postulant.CandidateAuthentication.Domain.Services;

namespace Jobsy.Postulant.CandidateAuthentication.Application.Internal.QueryServices;

/// <summary>
///     Candidate profile query service.
/// </summary>
/// <remarks>
///     This class implements the basic operations for a candidate profile query service.
/// </remarks>
/// <param name="candidateProfileRepository">The CandidateProfileRepository instance.</param>
public class CandidateProfileQueryService(ICandidateProfileRepository candidateProfileRepository)
    : ICandidateProfileQueryService
{
    /// <inheritdoc />
    public async Task<IEnumerable<CandidateProfile>> Handle(GetAllCandidateProfilesQuery query)
    {
        return await candidateProfileRepository.ListAsync();
    }

    /// <inheritdoc />
    public async Task<CandidateProfile?> Handle(GetCandidateProfileByIdQuery query)
    {
        return await candidateProfileRepository.FindByIdAsync(query.Id);
    }
}