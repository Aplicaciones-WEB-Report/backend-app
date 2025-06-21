namespace Jobsy.Postulant.CandidateAuthentication.Domain.Model.Queries;

/// <summary>
/// Query to retrieve a candidate profile by its ID.
/// </summary>
/// <param name="Id">The ID of the candidate profile</param>
public record GetCandidateProfileByIdQuery(int Id);