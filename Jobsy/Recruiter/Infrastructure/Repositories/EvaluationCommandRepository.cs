using Jobsy.Recruiter.Domain.Model.Aggregates;
using Jobsy.Recruiter.Domain.Repositories;
using Jobsy.Shared.Infrastructure.Persistencia.Configuration;

namespace Jobsy.Recruiter.InfraStructure.Repositories;

public class EvaluationCommandRepository : IEvaluationCommandRepository
{
    private readonly AppDbContext _context;

    public EvaluationCommandRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Evaluation> AddAsync(Evaluation evaluation)
    {
        _context.Evaluations.Add(evaluation);
        await _context.SaveChangesAsync();
        return evaluation;
    }

    public async Task<Evaluation> UpdateAsync(Evaluation evaluation)
    {
        _context.Evaluations.Update(evaluation);
        await _context.SaveChangesAsync();
        return evaluation;
    }

    public async Task DeleteAsync(Evaluation evaluation)
    {
        _context.Evaluations.Remove(evaluation);
        await _context.SaveChangesAsync();
    }
}