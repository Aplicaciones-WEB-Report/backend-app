using Jobsy.Recruiter.Domain.Model.Aggregates;

namespace Jobsy.Recruiter.Domain.Repositories;

public interface IEvaluationQueryRepository
{
    Task<Evaluation> GetByIdAsync(int id);
    Task<IEnumerable<Evaluation>> ListAsync();
}