using Jobsy.Recruiter.Domain.Model.Aggregates;
using Jobsy.Recruiter.Domain.Repositories;
using Jobsy.Shared.Infrastructure.Persistencia.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Jobsy.Recruiter.InfraStructure.Repositories;

public class EvaluationQueryRepository : IEvaluationQueryRepository
{
    private readonly AppDbContext _context;

    public EvaluationQueryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Evaluation> GetByIdAsync(int id)
    {
        return await _context.Evaluations.FindAsync(id);
    }

    public async Task<IEnumerable<Evaluation>> ListAsync()
    {
        return await _context.Evaluations.ToListAsync();
    }
}