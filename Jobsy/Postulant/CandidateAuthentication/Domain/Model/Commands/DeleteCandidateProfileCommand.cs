namespace Jobsy.Postulant.CandidateAuthentication.Domain.Model.Commands;

/// <summary>
/// Command to delete a candidate profile by ID.
/// </summary>
public record DeleteCandidateProfileCommand(int Id);