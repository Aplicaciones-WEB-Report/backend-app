using Jobsy.Postulant.CandidateAuthentication.Domain.Model.Aggregates;
using Jobsy.Postulant.CandidateAuthentication.Domain.Repositories;
using Jobsy.Shared.Infrastructure.Persistencia.Configuration;
using Jobsy.Shared.Infrastructure.Persistencia.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jobsy.Postulant.CandidateAuthentication.Infrastructure.Repositories;

/// <summary>
///     Candidate profile repository
/// </summary>
/// <remarks>
///     This class implements the basic operations for a candidate profile repository.
/// </remarks>
public class CandidateProfileRepository(AppDbContext context)
    : BaseRepository<CandidateProfile>(context), ICandidateProfileRepository
{
    /// <inheritdoc />
    public async Task<CandidateProfile?> FindByUserIdAsync(int id_Usuario)
    {
        return await Context.Set<CandidateProfile>()
            .FirstOrDefaultAsync(p => p.Id_Usuario == id_Usuario);
    }
}