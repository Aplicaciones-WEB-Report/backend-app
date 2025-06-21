using Jobsy.Postulant.CandidateAuthentication.Domain.Model.Aggregates;
using Jobsy.Postulant.CandidateAuthentication.Domain.Model.Commands;

namespace Jobsy.Postulant.CandidateAuthentication.Domain.Services;

/// <summary>
///     Interface for handling candidate profile commands.
/// </summary>
public interface ICandidateProfileCommandService
{
    /// <summary>
    ///     Handle the creation of a candidate profile.
    /// </summary>
    Task<CandidateProfile?> Handle(CreateCandidateProfileCommand command);

    /// <summary>
    ///     Handle the update of a candidate profile.
    /// </summary>
    Task<bool> Handle(UpdateCandidateProfileCommand command);

    /// <summary>
    ///     Handle the deletion of a candidate profile.
    /// </summary>
    Task<bool> Handle(DeleteCandidateProfileCommand command);
}