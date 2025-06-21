using Jobsy.Postulant.CandidateAuthentication.Domain.Model.Aggregates;
using Jobsy.Postulant.CandidateAuthentication.Domain.Model.Commands;
using Jobsy.Postulant.CandidateAuthentication.Domain.Repositories;
using Jobsy.Postulant.CandidateAuthentication.Domain.Services;
using Jobsy.Shared.Domain.Repositories;

namespace Jobsy.Postulant.CandidateAuthentication.Application.Internal.CommandServices;

/// <summary>
///     Candidate profile command service.
/// </summary>
/// <param name="candidateProfileRepository">The candidate profile repository instance.</param>
/// <param name="unitOfWork">The UnitOfWork instance.</param>
public class CandidateProfileCommandService(ICandidateProfileRepository candidateProfileRepository, IUnitOfWork unitOfWork)
    : ICandidateProfileCommandService
{
    /// <inheritdoc />
    public async Task<CandidateProfile?> Handle(CreateCandidateProfileCommand command)
    {
        var existingProfile = await candidateProfileRepository.FindByUserIdAsync(command.Id_Usuario);
        if (existingProfile != null)
            throw new Exception("Candidate profile already exists for the given user.");

        var candidateProfile = new CandidateProfile(command);
        
        try
        {
            await candidateProfileRepository.AddAsync(candidateProfile);
            await unitOfWork.CompleteAsync();
        }
        catch
        {
            return null;
        }

        return candidateProfile;
    }

    /// <inheritdoc />
    public async Task<bool> Handle(UpdateCandidateProfileCommand command)
    {
        var existing = await candidateProfileRepository.FindByIdAsync(command.Id);
        if (existing is null) return false;

        // Suponiendo que usas propiedades con setters privados
        existing.Update(command); // O hazlo manualmente si no tienes un método
        candidateProfileRepository.Update(existing);
        await unitOfWork.CompleteAsync();
        return true;
    }

    /// <inheritdoc />
    public async Task<bool> Handle(DeleteCandidateProfileCommand command)
    {
        var existing = await candidateProfileRepository.FindByIdAsync(command.Id);
        if (existing is null) return false;

        candidateProfileRepository.Remove(existing);
        await unitOfWork.CompleteAsync();
        return true;
    }
}
